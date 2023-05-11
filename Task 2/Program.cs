using System;
using System.Diagnostics;

namespace Task_2
{
    class Program
    {
        public class IpAddressChecker
        {
            public static bool IsIpAddressInRange(string ipAddress, string[] ipRanges)
            {
                Debug.WriteLine($"Checking IP address: {ipAddress}");
                foreach (string ipRange in ipRanges)
                {
                    Debug.WriteLine($"Checking IP range: {ipRange}");
                    switch (ipRange)
                    {
                        case var range when range.Contains("/"): // CIDR range
                            {
                                string[] parts = range.Split('/');
                                if (parts.Length != 2)
                                {
                                    throw new ArgumentException($"Invalid CIDR range: {range}");
                                }

                                string networkAddress = parts[0];
                                int subnetLength = int.Parse(parts[1]);
                                uint ip = IpStringToUint(ipAddress);
                                uint network = IpStringToUint(networkAddress);
                                uint mask = (subnetLength == 32) ? uint.MaxValue : ~(uint.MaxValue >> subnetLength);
                                uint maskedIp = ip & mask;
                                uint maskedNetwork = network & mask;

                                if (maskedIp == maskedNetwork)
                                {
                                    Debug.WriteLine($"IP address {ipAddress} is in CIDR range {range}");
                                    return true;
                                }

                                break;
                            }

                        case var range when range.Contains("-"): // Range of IP addresses
                            {
                                string[] parts = range.Split('-');
                                if (parts.Length != 2)
                                {
                                    throw new ArgumentException($"Invalid IP range: {range}");
                                }

                                uint startIp = IpStringToUint(parts[0]);
                                uint endIp = IpStringToUint(parts[1]);
                                uint ip = IpStringToUint(ipAddress);

                                if (ip >= startIp && ip <= endIp)
                                {
                                    Debug.WriteLine($"IP address {ipAddress} is in range {range}");
                                    return true;
                                }

                                break;
                            }

                        default: // Single IP address
                            if (ipAddress == ipRange)
                            {
                                Debug.WriteLine($"IP address {ipAddress} is in range {ipRange}");
                                return true;
                            }

                            break;
                    }
                }

                Debug.WriteLine($"IP address {ipAddress} is not in any range");
                return false;
            }

            private static uint IpStringToUint(string ipAddress)
            {
                string[] parts = ipAddress.Split('.');
                if (parts.Length != 4)
                {
                    throw new ArgumentException($"Invalid IP address: {ipAddress}");
                }

                uint result = 0;
                for (int i = 0; i < 4; i++)
                {
                    result = (result << 8) + uint.Parse(parts[i]);
                }

                return result;
            }

            static void Main()
            {
                string[] ipRanges = new string[]
                {
                "192.168.1.0/24",
                "10.0.0.1",
                "172.16.0.0-172.31.255.255"
                };

                string ipAddress = "192.168.1.50";
                bool isInRange = IpAddressChecker.IsIpAddressInRange(ipAddress, ipRanges);
                Console.WriteLine($"{ipAddress} is in range? {isInRange}");

                ipAddress = "10.0.0.1";
                isInRange = IpAddressChecker.IsIpAddressInRange(ipAddress, ipRanges);
                Console.WriteLine($"{ipAddress} is in range? {isInRange}");

                ipAddress = "172.20.30.40";
                isInRange = IpAddressChecker.IsIpAddressInRange(ipAddress, ipRanges);
                Console.WriteLine($"{ipAddress} is in range? {isInRange}");

                ipAddress = "192.168.2.1";
                isInRange = IpAddressChecker.IsIpAddressInRange(ipAddress, ipRanges);
                Console.WriteLine($"{ipAddress} is in range? {isInRange}");
            }
        }
    }
}

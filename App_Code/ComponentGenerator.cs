using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public class ComponentGenerator
    {
        public static List<Component> GetAllProcessors()
        {
            List<Component> processorDetails = new List<Component>
            {
                new Processor("Intel", "Core i3-9100", "3.60 GHz", "4 core", "$169.99"),
                new Processor("Intel", "Core i5-9600", "3.70 GHz", "6 core", "$339.99"),
                new Processor("Intel", "Core i7-9900", "3.60 GHz", "8 core", "$639.99"),
                new Processor("AMD", "Ryzen 3 2200", "3.50 GHz", "4 core", "$119.99"),
                new Processor("AMD", "Ryzen 5 2600", "3.40 GHz", "6 core", "$299.99"),
                new Processor("AMD", "Ryzen 7 1700", "3.20 GHz", "8 core", "$419.99")
            };
            return processorDetails;
        }

        public static List<Component> GetAllRAMs()
        {
            List<Component> ramDetails = new List<Component>
            {
                new RAM("G.Skill", "3000MHz", "DDR4 2 x 8GB", "$96.99"),
                new RAM("G.Skill", "3600MHz", "DDR4 2 x 8GB", "$142.99"),
                new RAM("G.Skill", "3600MHz", "DDR4 2 x 16GB", "$355.99"),
                new RAM("Corsair", "3000MHz", "DDR4 2 x 4GB", "$62.99"),
                new RAM("Corsair", "3000MHz", "DDR4 2 x 8GB", "$104.99"),
                new RAM("Corsair", "3200MHz", "DDR4 2 x 8GB", "$132.99"),
                new RAM("HyperX", "1600MHz", "DDR3 1 x 8GB", "$59.99"),
                new RAM("Crucial", "2666MHz", "DDR4 1 x 16GB", "101.99"),
            };
            return ramDetails;
        }

        public static List<Component> GetAllHardDrives()
        {
            List<Component> hardDriveDetails = new List<Component>
            {

                new HardDrive("Samsung", "SSD", "250GB", "$129.99"),
                new HardDrive("Samsung",  "SSD", "500GB", "$229.99"),
                new HardDrive("WD", "HDD", "1TB", "$59.99"),
                new HardDrive("WD", "HDD", "2TB", "$89.99"),
                new HardDrive("Seagate", "HDD", "1TB", "$79.99"),
                new HardDrive("Seagate", "HDD", "2TB", "$99.99"),
                new HardDrive("ADATA", "SSD", "250GB", "$129.99"),
                new HardDrive("Intel", "SSD", "250GB", "$139.99")
            };
            return hardDriveDetails;
        }

        public static List<Component> GetAllDisplays()
        {
            List<Component> displayDetails = new List<Component>
            {
                new Display("ASUS", "23'", "1920 x 1080", "5ms", "$184.99"),
                new Display("ASUS", "27'", "3840 x 2160", "4ms", "$959.99"),
                new Display("Dell", "27'", "1920 x 1080", "2ms", "$179.99"),
                new Display("Dell", "21'", "1920 x 1080", "5ms", "$119.99"),
                new Display("LG", "23'", "1920 x 1080", "5ms", "$159.99"),
                new Display("LG", "21'", "1920 x 1080", "5ms", "$169.99"),
                new Display("HP", "27'", "2560 x 1440", "4ms", "$379.99"),
                new Display("Lenovo", "24'", "2560 x 1440", "1ms", "$549.99")
            };
            return displayDetails;
        }

        public static List<Component> GetAllOSs()
        {
            List<Component> OSs = new List<Component>
            {
                new OS("Microsoft", "Windows 10 Home (64-Bit)", "$149.99"),
                new OS("Microsoft", "Windows 10 Pro (64-Bit)", "$169.99"),
                new OS("Microsoft", "Windows 8 Pro (64-Bit)", "$59.99"),
                new OS("Canonical", "Ubuntu 18.04 LTS", "$0.00"),

            };
            return OSs;
        }
    }
}
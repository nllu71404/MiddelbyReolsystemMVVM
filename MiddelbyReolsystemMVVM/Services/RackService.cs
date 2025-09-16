using System.Collections.Generic;
using MiddelbyReolsystemMVVM.Models;

namespace MiddelbyReolsystemMVVM.Services
{
    public class RackService : IRackService
    {
        /*
        private static IEnumerable<Rack> _racks = new List<Rack>();

        public RackService()
        {
            _racks = InitializePredefinedRacks();
        }
        */


        public List<Rack> _predefinedRacks = new List<Rack>
        {
                new Rack(1, RackStatus.Occupied, RackType.Standard),
                new Rack(2, RackStatus.Available, RackType.Premium),
                new Rack(3, RackStatus.Occupied, RackType.Premium),
                new Rack(4, RackStatus.Available, RackType.Standard),
                new Rack(5, RackStatus.Occupied, RackType.Standard),
                new Rack(6, RackStatus.Occupied, RackType.Premium),
                new Rack(7, RackStatus.Available, RackType.Standard),
                new Rack(8, RackStatus.Occupied, RackType.Standard),
                new Rack(9, RackStatus.Occupied, RackType.Premium),
                new Rack(10, RackStatus.Available, RackType.Premium),

                new Rack(11, RackStatus.Occupied, RackType.Standard),
                new Rack(12, RackStatus.Available, RackType.Standard),
                new Rack(13, RackStatus.Occupied, RackType.Premium),
                new Rack(14, RackStatus.Occupied, RackType.Standard),
                new Rack(15, RackStatus.Available, RackType.Premium),
                new Rack(16, RackStatus.Occupied, RackType.Standard),
                new Rack(17, RackStatus.Occupied, RackType.Premium),
                new Rack(18, RackStatus.Available, RackType.Standard),
                new Rack(19, RackStatus.Occupied, RackType.Standard),
                new Rack(20, RackStatus.Occupied, RackType.Premium),

                new Rack(21, RackStatus.Available, RackType.Standard),
                new Rack(22, RackStatus.Occupied, RackType.Standard),
                new Rack(23, RackStatus.Available, RackType.Premium),
                new Rack(24, RackStatus.Occupied, RackType.Premium),
                new Rack(25, RackStatus.Occupied, RackType.Standard),
                new Rack(26, RackStatus.Available, RackType.Standard),
                new Rack(27, RackStatus.Occupied, RackType.Premium),
                new Rack(28, RackStatus.Occupied, RackType.Standard),
                new Rack(29, RackStatus.Available, RackType.Premium),
                new Rack(30, RackStatus.Occupied, RackType.Standard),

                new Rack(31, RackStatus.Occupied, RackType.Premium),
                new Rack(32, RackStatus.Available, RackType.Standard),
                new Rack(33, RackStatus.Occupied, RackType.Standard),
                new Rack(34, RackStatus.Occupied, RackType.Premium),
                new Rack(35, RackStatus.Available, RackType.Standard),
                new Rack(36, RackStatus.Occupied, RackType.Standard),
                new Rack(37, RackStatus.Available, RackType.Premium),
                new Rack(38, RackStatus.Occupied, RackType.Premium),
                new Rack(39, RackStatus.Occupied, RackType.Standard),
                new Rack(40, RackStatus.Available, RackType.Standard),

                new Rack(41, RackStatus.Occupied, RackType.Premium),
                new Rack(42, RackStatus.Occupied, RackType.Standard),
                new Rack(43, RackStatus.Available, RackType.Premium),
                new Rack(44, RackStatus.Occupied, RackType.Standard),
                new Rack(45, RackStatus.Occupied, RackType.Premium),
                new Rack(46, RackStatus.Available, RackType.Standard),
                new Rack(47, RackStatus.Occupied, RackType.Standard),
                new Rack(48, RackStatus.Occupied, RackType.Premium),
                new Rack(49, RackStatus.Available, RackType.Standard),
                new Rack(50, RackStatus.Occupied, RackType.Standard),

                new Rack(51, RackStatus.Available, RackType.Premium),
                new Rack(52, RackStatus.Occupied, RackType.Standard),
                new Rack(53, RackStatus.Occupied, RackType.Premium),
                new Rack(54, RackStatus.Available, RackType.Standard),
                new Rack(55, RackStatus.Occupied, RackType.Standard),
                new Rack(56, RackStatus.Occupied, RackType.Premium),
                new Rack(57, RackStatus.Available, RackType.Premium),
                new Rack(58, RackStatus.Occupied, RackType.Standard),
                new Rack(59, RackStatus.Occupied, RackType.Premium),
                new Rack(60, RackStatus.Available, RackType.Standard),

                new Rack(61, RackStatus.Occupied, RackType.Standard),
                new Rack(62, RackStatus.Available, RackType.Premium),
                new Rack(63, RackStatus.Occupied, RackType.Premium),
                new Rack(64, RackStatus.Occupied, RackType.Standard),
                new Rack(65, RackStatus.Available, RackType.Standard),
                new Rack(66, RackStatus.Occupied, RackType.Premium),
                new Rack(67, RackStatus.Occupied, RackType.Standard),
                new Rack(68, RackStatus.Available, RackType.Premium),
                new Rack(69, RackStatus.Occupied, RackType.Standard),
                new Rack(70, RackStatus.Occupied, RackType.Premium),

                new Rack(71, RackStatus.Available, RackType.Standard),
                new Rack(72, RackStatus.Occupied, RackType.Standard),
                new Rack(73, RackStatus.Occupied, RackType.Premium),
                new Rack(74, RackStatus.Available, RackType.Premium),
                new Rack(75, RackStatus.Occupied, RackType.Standard),
                new Rack(76, RackStatus.Occupied, RackType.Premium),
                new Rack(77, RackStatus.Available, RackType.Standard),
                new Rack(78, RackStatus.Occupied, RackType.Standard),
                new Rack(79, RackStatus.Other, RackType.Premium),
                new Rack(80, RackStatus.Available, RackType.Premium),

        };

        public IEnumerable<Rack> GetRacksByStatus(RackStatus status)
        {
            return _predefinedRacks.Where(r => r.RackStatus == status);
        }

    }

 }


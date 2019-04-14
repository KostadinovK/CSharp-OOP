using System;
using System.Linq;
using MortalEngines.Common;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using MortalEngines.Factories.Contracts;
using MortalEngines.Repositories.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private IPilotRepository pilotRepository;
        private IMachineRepository machineRepository;

        private IPilotFactory pilotFactory;
        private IMachineFactory machineFactory;

        public MachinesManager(IPilotRepository pilotRepository, IMachineRepository machineRepository, IPilotFactory pilotFactory, IMachineFactory machineFactory)
        {
            this.pilotRepository = pilotRepository;
            this.machineRepository = machineRepository;
            this.pilotFactory = pilotFactory;
            this.machineFactory = machineFactory;
        }

        public string HirePilot(string name)
        {
            if (pilotRepository.ContainsPilot(name))
            {
                return String.Format(OutputMessages.PilotExists, name);
            }

            var pilot = pilotFactory.CreatePilot("Pilot", name);
            pilotRepository.AddPilot(pilot);

            return String.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machineRepository.ContainsMachine(name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }

            var tank = machineFactory.CreateMachine("Tank", name, attackPoints, defensePoints);
            machineRepository.AddMachine(tank);

            return String.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machineRepository.ContainsMachine(name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }

            var fighter = machineFactory.CreateMachine("Fighter", name, attackPoints, defensePoints);
            machineRepository.AddMachine(fighter);

            var isAggressive = ((IFighter) fighter).AggressiveMode;
            if (isAggressive)
            {
                return String.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, "ON");
            }

            return String.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilotRepository.Pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            var machine = machineRepository.Machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                return String.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (machine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return String.Format(OutputMessages.MachineHasPilotAlready, machine.Name);
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return String.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machineRepository.Machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defendingMachine = machineRepository.Machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (defendingMachine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, attackingMachine.Name);
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine.Name);
            }

            attackingMachine.Attack(defendingMachine);

            return String.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = pilotRepository.Pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilot == null)
            {
                return String.Format(OutputMessages.PilotNotFound, pilotReporting);
            }

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = machineRepository.Machines.FirstOrDefault(m => m.Name == machineName);

            if (machine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, machineName);
            }

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = machineRepository.Machines.FirstOrDefault(m => m.Name == fighterName);

            if (fighter == null)
            {
                return String.Format(OutputMessages.MachineNotFound, fighterName);
            }

            ((IFighter)fighter).ToggleAggressiveMode();

            return String.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = machineRepository.Machines.FirstOrDefault(m => m.Name == tankName);

            if (tank == null)
            {
                return String.Format(OutputMessages.MachineNotFound, tankName);
            }

            ((ITank)tank).ToggleDefenseMode();

            return String.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}
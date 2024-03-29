﻿
namespace OnlineShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Constants;
    using Common.Enums;
    using Models.Products.Computers;
    using Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;

    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private IComputer computer;
        private IComponent componet;
        private IPeripheral peripheral;

        public Controller()
        {
            this.computers = new HashSet<IComputer>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {

            this.computer = ValidateComputer(computerId, this.computers);

            if (this.computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));

            }

            if (this.computer.Components.Any(c => c.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponentId));
            }

            if (!Enum.TryParse(componentType, out ComponentType validComponent))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComponentType));
            }

            if (validComponent == ComponentType.CentralProcessingUnit)
            {
                this.componet = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (validComponent == ComponentType.Motherboard)
            {
                this.componet = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (validComponent == ComponentType.PowerSupply)
            {
                this.componet = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (validComponent == ComponentType.RandomAccessMemory)
            {
                this.componet = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (validComponent == ComponentType.SolidStateDrive)
            {
                this.componet = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (validComponent == ComponentType.VideoCard)
            {
                this.componet = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            this.computer.AddComponent(componet);

            return string.Format(SuccessMessages.AddedComponent, componet.GetType().Name , id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComputerId));
            }

            if (!Enum.TryParse(computerType, out ComputerType validComputer))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComputerType));
            }

            if (validComputer == ComputerType.DesktopComputer)
            {
                this.computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (validComputer == ComputerType.Laptop)
            {
                this.computer = new Laptop(id, manufacturer, model, price);
            }

            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {

            this.computer = ValidateComputer(computerId, computers);

            if (this.computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            if (this.computer.Peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheralId));
            }

            if (!Enum.TryParse(peripheralType, out PeripheralType validPeripheral))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidPeripheralType));
            }

            if (validPeripheral == PeripheralType.Headset)
            {
                this.peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (validPeripheral == PeripheralType.Keyboard)
            {
                this.peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (validPeripheral == PeripheralType.Monitor)
            {
                this.peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (validPeripheral == PeripheralType.Mouse)
            {
                this.peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            this.computer.AddPeripheral(this.peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, this.peripheral.Id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            this.computer = this.computers.OrderByDescending(c => c.OverallPerformance).Where(c => c.Price <= budget).FirstOrDefault();

            if (this.computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(this.computer);

            return this.computer.ToString();
        }

        public string BuyComputer(int id)
        {

            this.computer = ValidateComputer(id, this.computers);

            if (this.computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            this.computers.Remove(this.computer);

            return this.computer.ToString();
        }

        public string GetComputerData(int id)
        {
            this.computer = ValidateComputer(id, this.computers);

            if (this.computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            return this.computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
 
            this.computer = ValidateComputer(computerId, this.computers);

            if (this.computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            this.computer.RemoveComponent(componentType);

            return string.Format(SuccessMessages.RemovedComponent, componentType, this.componet.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            this.computer = ValidateComputer(computerId, this.computers);

            if (this.computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            this.computer.RemovePeripheral(peripheralType);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, this.peripheral.Id);
        }

        private IComputer ValidateComputer(int computerId, ICollection<IComputer> computers) => this.computers.FirstOrDefault(c => c.Id == computerId);
   
    }
}

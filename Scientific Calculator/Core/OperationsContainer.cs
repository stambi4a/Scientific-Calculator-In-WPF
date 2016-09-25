namespace Scientific_Calculator.Core
{
    using System;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Interfaces;

    [Core]
    public class OperationsContainer: IOperationsContainer
    {
        private readonly ICalculationRepository calculationRepository;

        [Inject]
        private readonly IRepositoryHandler repositoryHandler;

        [Inject]
        private readonly IMethodInvoker methodInvoker;

        [Inject]
        private readonly ICalculationHandler calculationHandler;

        private readonly IDependencyContainer dependencyContainer;

        public OperationsContainer(ICalculationRepository calculationRepository, IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
            this.calculationRepository = calculationRepository;
        }

        public ICalculationHandler CalculationHandler => this.calculationHandler;

        public void Execute(string input)
        {
            try
            {
                this.calculationHandler.Execute(input);
            }
            catch (Exception tie)
            {
                this.CalculationHandler.CalculationHandlerExceptionHandlingMethod(tie);
            }
            
        }

        public void RestoreResultFromMemory()
        {
            throw new System.NotImplementedException();
        }
    }
}

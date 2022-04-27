using System;

using R5T.Findhorn;
using R5T.Lombardy;
using R5T.Zografou;using R5T.T0064;


namespace R5T.Glenrothes.Findhorn
{[ServiceImplementationMarker]
    public class DataDirectoryTestingDataDirectoryPathProvider : ITestingDataDirectoryPathProvider,IServiceImplementation
    {
        private IDataDirectoryPathProvider DataDirectoryPathProvider { get; }
        private ITestingDataDirectoryNameConvention TestingDataDirectoryNameConvention { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public DataDirectoryTestingDataDirectoryPathProvider(
            IDataDirectoryPathProvider dataDirectoryPathProvider,
            ITestingDataDirectoryNameConvention testingDataDirectoryNameConvention,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.DataDirectoryPathProvider = dataDirectoryPathProvider;
            this.TestingDataDirectoryNameConvention = testingDataDirectoryNameConvention;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetTestingDataDirectoryPath()
        {
            var dataDirectoryPath = this.DataDirectoryPathProvider.GetDataDirectoryPath();

            var testingDataDirectoryName = this.TestingDataDirectoryNameConvention.GetTestingDataDirectoryName();

            var testingDataDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPath(dataDirectoryPath, testingDataDirectoryName);
            return testingDataDirectoryPath;
        }
    }
}

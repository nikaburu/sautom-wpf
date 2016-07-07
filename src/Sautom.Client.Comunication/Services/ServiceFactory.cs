using System.ServiceModel;
using Prism.Events;
using Sautom.Client.Comunication.AuthorizationService;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.CommonService;
using Sautom.Client.Comunication.FileService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.ReportService;

namespace Sautom.Client.Comunication.Services
{
    public class ServiceFactory
    {
        public IEventAggregator EventAggregator { get; set; }

        public ServiceFactory(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public IQueriesService GetQueriesService()
        {
            var serviceClient = new QueriesServiceClient();
            InitCredentials(serviceClient);

            return new QueriesServiceAdapter(serviceClient, EventAggregator);
        }

        public ICommandService GetCommandsService()
        {
            var serviceClient = new CommandServiceClient();
            InitCredentials(serviceClient);

            return serviceClient;
        }

        public ICommonService GetCommonService()
        {
            var serviceClient = new CommonServiceClient();
            InitCredentials(serviceClient);

            return serviceClient;
        }

        public IFileService GetFilesService()
        {
            var serviceClient = new FileServiceClient();
            InitCredentials(serviceClient);

            return new FilesServiceAdapter(serviceClient, EventAggregator);
        }

        public IReportService GetReportesService()
        {
            var serviceClient = new ReportServiceClient();
            InitCredentials(serviceClient);

            return new ReportesServiceAdapter(serviceClient, EventAggregator);
        }

        public IAuthorizationService GetAuthorizationService()
        {
            var serviceClient = new AuthorizationServiceClient();
            
            return new AuthorizationServiceAdapter(serviceClient, EventAggregator);
        }

        private static void InitCredentials<TChannel>(ClientBase<TChannel> serviceClient) where TChannel : class
        {
            serviceClient.ClientCredentials.UserName.UserName = UserPrincipal.PrincipalInstance.Identity.Name;//Thread.CurrentPrincipal.Identity.Name;
            serviceClient.ClientCredentials.UserName.Password = "1234";
        }

        public static ServiceFactory Get(IEventAggregator eventAggregator)
        {
            return new ServiceFactory(eventAggregator);
        }
    }
}

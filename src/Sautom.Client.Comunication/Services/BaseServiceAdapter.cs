using System;
using Prism.Events;
using Sautom.Client.Comunication.Events;
using Sautom.Client.Comunication.Properties;

namespace Sautom.Client.Comunication.Services
{
    internal abstract class BaseServiceAdapter
    {
        private IEventAggregator EventAggregator { get; set; }

        protected BaseServiceAdapter(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        #region Private members

        protected Guid ShowOperationStarted()
        {
            Nortification nortification = new Nortification()
                                              {
                                                  NortificationId = Guid.NewGuid(),
                                                  NortificationText = Resources.Label_Loading,
                                                  NortificationType = NortificationType.Information,
                                                  CloseAfter = int.MaxValue
                                              };

            EventAggregator.GetEvent<NortificationEvent>().Publish(nortification);
            return nortification.NortificationId;
        }

        protected void HideOperationStarted(Guid id)
        {
            EventAggregator.GetEvent<NortificationEndedEvent>().Publish(id);
        }

        protected void ShowExceptionAlert(string message)
        {
            Nortification nortification = new Nortification()
            {
                NortificationId = Guid.NewGuid(),
                NortificationText = message,
                NortificationType = NortificationType.Error,
                CloseAfter = 5000
            };

            EventAggregator.GetEvent<NortificationEvent>().Publish(nortification);
        }

        protected TResult ExceptionAware<TResult>(Func<TResult> action) where TResult : class
        {
            return ExceptionAware(action, () => null);
        }

        protected TResult ExceptionAware<TResult>(Func<TResult> action, Func<TResult> ifFault) where TResult : class
        {
            Guid dialogId = Guid.Empty;
            try
            {
                dialogId = ShowOperationStarted();

                return action.Invoke();
            }
            catch (Exception exp)
            {
                var message = exp.Message;
                while (exp.InnerException != null)
                {
                    exp = exp.InnerException;
                    message += "; " + exp.Message;
                }

                ShowExceptionAlert(message);
                return ifFault.Invoke();
            }
            finally
            {
                HideOperationStarted(dialogId);
            }
        }

        #endregion
    }
}

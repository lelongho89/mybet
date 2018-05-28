using Abp.Web.Mvc.Views;

namespace FunBet.Web.Views
{
    public abstract class FunBetWebViewPageBase : FunBetWebViewPageBase<dynamic>
    {

    }

    public abstract class FunBetWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected FunBetWebViewPageBase()
        {
            LocalizationSourceName = FunBetConsts.LocalizationSourceName;
        }
    }
}
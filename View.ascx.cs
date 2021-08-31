/*
' Copyright (c) 2021  Shift7Digital.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using DotNetNuke.Entities.Tabs;

using System;
using System.IO;
using System.Globalization;

namespace Shift7Digital.Modules.Shift7AnalyticsAdobeAnalyticsModule
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from AdobeAnalyticsModuleModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : AdobeAnalyticsModuleModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TabInfo tabInfo = PortalSettings.ActiveTab;
            try
            {
                ViewState["qcPageName"] = tabInfo.TabName;
                ViewState["qcCountry"] = RegionInfo.CurrentRegion.TwoLetterISORegionName;
                ViewState["qcLanguage"] = Request.UserLanguages[0] ?? "en-us";
                ViewState["qcDomain"] = Request.Url.Host;
                // TODO: Statement below meant to gather page type of template (i.e. product-detail-page, campaign-home-page, etc.)
                // TODO: Skin name is used, if better resource name applies then replace assignment below
                ViewState["qcPageType"] = !string.IsNullOrWhiteSpace(tabInfo.SkinPath) ? new DirectoryInfo(tabInfo.SkinPath).Name : "n/a";
                ViewState["qcPrimaryCategory"] = ((TabInfo)tabInfo.BreadCrumbs[0]).Title; 
                ViewState["qcSubCategory1"] = tabInfo.BreadCrumbs.Count >= 2 ? ((TabInfo)tabInfo.BreadCrumbs[1]).Title : "n/a";
                ViewState["qcSubCategory2"] = tabInfo.BreadCrumbs.Count >= 3 ? ((TabInfo)tabInfo.BreadCrumbs[2]).Title : "n/a";
                ViewState["qcSubCategory3"] = tabInfo.BreadCrumbs.Count >= 4 ? ((TabInfo)tabInfo.BreadCrumbs[3]).Title : "n/a";
                ViewState["qcSubCategory4"] = tabInfo.BreadCrumbs.Count >= 5 ? ((TabInfo)tabInfo.BreadCrumbs[4]).Title : "n/a";
                ViewState["qcSubCategory5"] = tabInfo.BreadCrumbs.Count >= 6 ? ((TabInfo)tabInfo.BreadCrumbs[5]).Title : "n/a";
                ;
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }
    }
}
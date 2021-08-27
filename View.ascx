<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Shift7Digital.Modules.Shift7AnalyticsAdobeAnalyticsModule.View" %>

<!-- Adobe Analytics Script Start-->
    <script type="text/javascript">
        window.digitalData = window.digitalData || [];
        window.digitalData.push({
            event: "pageView",
            page: {
                pageInfo: {
                    pageName: "<%= (string)ViewState["qcPageName"] %>",
                    country: "<%= (string)ViewState["qcCountry"] %>",
                    language: "<%= (string)ViewState["qcLanguage"] %>",
                    domain: "<%= (string)ViewState["qcDomain"] %>"
                },
                category: {
                    pageType: "<%= (string)ViewState["qcPageType"] %>",
                    primaryCategory: "<%= (string)ViewState["qcPrimaryCategory"] %>",
                    subCategory1: "<%= (string)ViewState["qcSubCategory1"] %>",
                    subCategory2: "<%= (string)ViewState["qcSubCategory2"] %>",
                    subCategory3: "<%= (string)ViewState["qcSubCategory3"] %>",
                    subCategory4: "<%= (string)ViewState["qcSubCategory4"] %>",
                    subCategory5: "<%= (string)ViewState["qcSubCategory5"] %>"
                }
            }
        });
    </script>
<!-- Adobe Analytics Script End -->

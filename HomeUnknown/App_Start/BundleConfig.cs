using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace HomeUnknown
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/ajaxPrefilters.js",
                "~/Scripts/app/app.bindings.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/login.viewmodel.js",
                "~/Scripts/app/register.viewmodel.js",
                "~/Scripts/app/registerExternal.viewmodel.js",
                "~/Scripts/app/manage.viewmodel.js",
                "~/Scripts/app/userInfo.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/arbor").Include(
                "~/Scripts/arbor.js"
                , "~/Scripts/arbor-tween.js"
                , "~/Scripts/arborsrc/dev.js"
                , "~/Scripts/arborsrc/etc.js"
                , "~/Scripts/arborsrc/hermetic.js"
                , "~/Scripts/arborsrc/kernel.js"
                , "~/Scripts/arborsrc/graphics/colors.js"
                , "~/Scripts/arborsrc/graphics/graphics.js"
                , "~/Scripts/arborsrc/graphics/primitives.js"
                , "~/Scripts/arborsrc/physics/atoms.js"
                , "~/Scripts/arborsrc/physics/barnes-hut.js"
                , "~/Scripts/arborsrc/physics/physics.js"
                , "~/Scripts/arborsrc/physics/system.js"
                , "~/Scripts/arborsrc/physics/worker.js"
                , "~/Scripts/arborsrc/tween/easing.js"
                , "~/Scripts/arborsrc/tween/tween.js"));

            bundles.Add(new ScriptBundle("~/bundles/morphButtons").Include(
                "~/Scripts/morphbuttons/classie.js"
                , "~/Scripts/morphbuttons/modernizr.custom.js"
                , "~/Scripts/morphbuttons/uiMorphingButton_fixed.js"
                , "~/Scripts/morphbuttons/uiMorphingButton_inflow.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/css/bootstrap.css"
                 , "~/Content/css/site.css"
                 , "~/Content/css/component.css"
                 , "~/Content/css/content.css"
                 , "~/Content/css/demo.css"
                 , "~/Content/css/normalize.css"
                 ));
        }
    }
}

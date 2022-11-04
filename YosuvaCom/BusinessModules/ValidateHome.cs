﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace YosuvaCom.BusinessModules
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateHome recording.
    /// </summary>
    [TestModule("f7f31765-e6a9-4c8d-8f90-8f52cc0f92c9", ModuleType.Recording, 1)]
    public partial class ValidateHome : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::YosuvaCom.YosuvaComRepository repository.
        /// </summary>
        public static global::YosuvaCom.YosuvaComRepository repo = global::YosuvaCom.YosuvaComRepository.Instance;

        static ValidateHome instance = new ValidateHome();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateHome()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateHome Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (InnerText='Share what you Learned !!! Happy Learning !!!') on item 'YosuvaCom.Welcome_Msg'.", repo.YosuvaCom.Welcome_MsgInfo, new RecordItemIndex(0));
            Validate.AttributeEqual(repo.YosuvaCom.Welcome_MsgInfo, "InnerText", "Share what you Learned !!! Happy Learning !!!");
            Delay.Milliseconds(0);
            
            Report.Screenshot(ReportLevel.Info, "User", "", repo.YosuvaCom.Self, false, new RecordItemIndex(1));
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}

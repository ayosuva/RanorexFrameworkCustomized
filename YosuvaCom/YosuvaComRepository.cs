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
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace YosuvaCom
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the YosuvaComRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("3990b755-f4de-48a6-807b-46224209af53")]
    public partial class YosuvaComRepository : RepoGenBaseFolder
    {
        static YosuvaComRepository instance = new YosuvaComRepository();
        YosuvaComRepositoryFolders.YosuvaComAppFolder _yosuvacom;

        /// <summary>
        /// Gets the singleton class instance representing the YosuvaComRepository element repository.
        /// </summary>
        [RepositoryFolder("3990b755-f4de-48a6-807b-46224209af53")]
        public static YosuvaComRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public YosuvaComRepository() 
            : base("YosuvaComRepository", "/", null, 0, false, "3990b755-f4de-48a6-807b-46224209af53", ".\\RepositoryImages\\YosuvaComRepository3990b755.rximgres")
        {
            _yosuvacom = new YosuvaComRepositoryFolders.YosuvaComAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("3990b755-f4de-48a6-807b-46224209af53")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The YosuvaCom folder.
        /// </summary>
        [RepositoryFolder("7a09804a-447b-47c8-a1bc-5ff78f4728ca")]
        public virtual YosuvaComRepositoryFolders.YosuvaComAppFolder YosuvaCom
        {
            get { return _yosuvacom; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class YosuvaComRepositoryFolders
    {
        /// <summary>
        /// The YosuvaComAppFolder folder.
        /// </summary>
        [RepositoryFolder("7a09804a-447b-47c8-a1bc-5ff78f4728ca")]
        public partial class YosuvaComAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _first_nameInfo;
            RepoItemInfo _last_nameInfo;
            RepoItemInfo _submitInfo;
            RepoItemInfo _welcome_msgInfo;

            /// <summary>
            /// Creates a new YosuvaCom  folder.
            /// </summary>
            public YosuvaComAppFolder(RepoGenBaseFolder parentFolder) :
                    base("YosuvaCom", "/dom[@domain='yosuva.com']", parentFolder, 30000, null, false, "7a09804a-447b-47c8-a1bc-5ff78f4728ca", "")
            {
                _first_nameInfo = new RepoItemInfo(this, "First_Name", ".//input[#'fname']", "", 30000, null, "febadc77-14bf-46ab-a087-89b4ca494b7e");
                _last_nameInfo = new RepoItemInfo(this, "Last_Name", ".//input[#'lname']", "", 30000, null, "3b64d4c0-75aa-4dc9-adff-b73dfb5eba3c");
                _submitInfo = new RepoItemInfo(this, "Submit", ".//input[@type='submit']", "", 30000, null, "d2ea2f2e-50ce-4ff5-b0cc-8c5f59644170");
                _welcome_msgInfo = new RepoItemInfo(this, "Welcome_Msg", ".//div[#'top']/header//p[@innertext>'Share what you Learned !!!']", "", 30000, null, "79a6d9ce-0d87-407c-832a-01d65d4abfd1");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("7a09804a-447b-47c8-a1bc-5ff78f4728ca")]
            public virtual Ranorex.WebDocument Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.WebDocument>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("7a09804a-447b-47c8-a1bc-5ff78f4728ca")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The First_Name item.
            /// </summary>
            [RepositoryItem("febadc77-14bf-46ab-a087-89b4ca494b7e")]
            public virtual Ranorex.InputTag First_Name
            {
                get
                {
                    return _first_nameInfo.CreateAdapter<Ranorex.InputTag>(true);
                }
            }

            /// <summary>
            /// The First_Name item info.
            /// </summary>
            [RepositoryItemInfo("febadc77-14bf-46ab-a087-89b4ca494b7e")]
            public virtual RepoItemInfo First_NameInfo
            {
                get
                {
                    return _first_nameInfo;
                }
            }

            /// <summary>
            /// The Last_Name item.
            /// </summary>
            [RepositoryItem("3b64d4c0-75aa-4dc9-adff-b73dfb5eba3c")]
            public virtual Ranorex.InputTag Last_Name
            {
                get
                {
                    return _last_nameInfo.CreateAdapter<Ranorex.InputTag>(true);
                }
            }

            /// <summary>
            /// The Last_Name item info.
            /// </summary>
            [RepositoryItemInfo("3b64d4c0-75aa-4dc9-adff-b73dfb5eba3c")]
            public virtual RepoItemInfo Last_NameInfo
            {
                get
                {
                    return _last_nameInfo;
                }
            }

            /// <summary>
            /// The Submit item.
            /// </summary>
            [RepositoryItem("d2ea2f2e-50ce-4ff5-b0cc-8c5f59644170")]
            public virtual Ranorex.InputTag Submit
            {
                get
                {
                    return _submitInfo.CreateAdapter<Ranorex.InputTag>(true);
                }
            }

            /// <summary>
            /// The Submit item info.
            /// </summary>
            [RepositoryItemInfo("d2ea2f2e-50ce-4ff5-b0cc-8c5f59644170")]
            public virtual RepoItemInfo SubmitInfo
            {
                get
                {
                    return _submitInfo;
                }
            }

            /// <summary>
            /// The Welcome_Msg item.
            /// </summary>
            [RepositoryItem("79a6d9ce-0d87-407c-832a-01d65d4abfd1")]
            public virtual Ranorex.PTag Welcome_Msg
            {
                get
                {
                    return _welcome_msgInfo.CreateAdapter<Ranorex.PTag>(true);
                }
            }

            /// <summary>
            /// The Welcome_Msg item info.
            /// </summary>
            [RepositoryItemInfo("79a6d9ce-0d87-407c-832a-01d65d4abfd1")]
            public virtual RepoItemInfo Welcome_MsgInfo
            {
                get
                {
                    return _welcome_msgInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}

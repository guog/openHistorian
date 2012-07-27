﻿//******************************************************************************************************
//  PartitionInitializerGenerationSettings.cs - Gbtc
//
//  Copyright © 2012, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  7/24/2012 - Steven E. Chisholm
//       Generated original version of source code. 
//       
//
//******************************************************************************************************

using System.Collections.Generic;
using System.Data;
using System.IO;
using openHistorian.V2.Collections;
using openHistorian.V2.Server.Configuration;

namespace openHistorian.V2.Server.Database
{
    public class ArchiveInitializerGenerationSettings : ISupportsReadonly<ArchiveInitializerGenerationSettings>
    {
        bool m_isReadOnly;
        string m_name;
        bool m_isMemoryArchive;
        FolderListSettings m_savePath;
        long m_initialSize;
        long m_autoGrowthSize;

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                if (m_isReadOnly)
                    throw new ReadOnlyException("Object has been set as read only");
                m_name = value;
            }
        }

        public bool IsMemoryArchive
           {
            get
            {
                return m_isMemoryArchive;
            }
            set
            {
                if (m_isReadOnly)
                    throw new ReadOnlyException("Object has been set as read only");
                m_isMemoryArchive = value;
            }
        }

        public FolderListSettings SavePaths
        {
            get
            {
                return m_savePath;
            }
            set
            {
                if (m_isReadOnly)
                    throw new ReadOnlyException("Object has been set as read only");
                m_savePath = value;
            }
        }

        public long InitialSize
        {
            get
            {
                return m_initialSize;
            }
            set
            {
                if (m_isReadOnly)
                    throw new ReadOnlyException("Object has been set as read only");
                m_initialSize = value;
            }
        }

        public long AutoGrowthSize
        {
            get
            {
                return m_autoGrowthSize;
            }
            set
            {
                if (m_isReadOnly)
                    throw new ReadOnlyException("Object has been set as read only");
                m_autoGrowthSize = value;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return m_isReadOnly;
            }
            set
            {
                if (value ^ m_isReadOnly) //if values are different
                {
                    if (m_isReadOnly)
                        throw new ReadOnlyException("Object has been set as read only and cannot be reversed");
                    m_isReadOnly = true;
                }
            }
        }

        public ArchiveInitializerGenerationSettings EditableClone()
        {
            throw new System.NotImplementedException();
        }
    }
}

﻿//******************************************************************************************************
//  DatabaseInfo.cs - Gbtc
//
//  Copyright © 2014, Grid Protection Alliance.  All Rights Reserved.
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
//  3/1/2014 - Steven E. Chisholm
//       Generated original version of source code. 
//
//******************************************************************************************************

using System;
using GSF.SortedTreeStore.Tree;

namespace GSF.SortedTreeStore.Engine
{
    public class DatabaseInfo
    {
        public DatabaseInfo(string databaseName, SortedTreeTypeBase key, SortedTreeTypeBase value)
        {
            DatabaseName = databaseName;
            KeyTypeID = key.GenericTypeGuid;
            KeyType = key.GetType();
            ValueTypeID = value.GenericTypeGuid;
            ValueType = value.GetType();
        }

        public string DatabaseName { get; private set; }

        public Guid KeyTypeID { get; private set; }

        public Guid ValueTypeID { get; private set; }

        public Type KeyType { get; private set; }

        public Type ValueType { get; private set; }
    }
}
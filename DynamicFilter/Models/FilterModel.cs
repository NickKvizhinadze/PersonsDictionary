﻿using DynamicFilter.Enums;
using DynamicFilter.Extentions;
using System;

namespace DynamicFilter.Models
{
    internal class FilterModel
    {
        #region Constructor
        internal FilterModel()
        {
        }

        #endregion

        #region Properties
        internal string PropertyName { get; set; }
        internal Type PropertyType { get; set; }
        internal Type ValueType { get; set; }
        internal object Value { get; set; }
        internal string MethodName { get; set; }
        internal ConditionalOperators? ConditionalOperator { get; set; }
        internal string FilterPropertyName { get; set; }
        internal bool AlreadyUsed { get; set; }
        #endregion

        #region Methods
        internal bool IsValid()
        {
            if (string.IsNullOrEmpty(PropertyName))
                return false;

            if (PropertyType == null)
                return false;

            if (Value == null || Value.IsNullOrEmptyArray())
                return false;

            if (string.IsNullOrEmpty(MethodName))
                return false;
            return true;
        }
        #endregion
    }
}


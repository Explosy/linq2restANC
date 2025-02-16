// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntExpressionFactory.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the IntExpressionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2Rest.Parser.Readers
{
    using System;
    using System.Linq.Expressions;

    internal class IntExpressionFactory : ValueExpressionFactoryBase<int>
    {
        public override ConstantExpression Convert(string token)
        {
            int number;
            if (int.TryParse(token, out number))
            {
                return Expression.Constant(number);
            }

            throw new FormatException("Could not read " + token + " as integer.");
        }
    }
}
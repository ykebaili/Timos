// SET request PDU.
// Copyright (C) 2008-2010 Malcolm Crowe, Lex Li, and other contributors.
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/1
 * Time: 20:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace futurocom.snmp
{
    /// <summary>
    /// SET request PDU.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pdu")]
    [Serializable]
    public class SetRequestPdu : ISnmpPdu
    {
        private byte[] _raw;
        private readonly Sequence _varbindSection;

        /// <summary>
        /// Creates a <see cref="SetRequestPdu"/> instance with all contents.
        /// </summary>
        /// <param name="requestId">The request id.</param>
        /// <param name="errorStatus">Error status</param>
        /// <param name="errorIndex">Error index</param>
        /// <param name="variables">Variables</param>
        [Obsolete("Please use other overloads.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "errorStatus")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "errorIndex")]
        public SetRequestPdu(int requestId, ErrorCode errorStatus, int errorIndex, IList<Variable> variables)
            : this(requestId, variables)
        {
        }
        
        /// <summary>
        /// Creates a <see cref="SetRequestPdu"/> instance with all contents.
        /// </summary>
        /// <param name="requestId">The request id.</param>
        /// <param name="variables">Variables</param>
        public SetRequestPdu(int requestId, IList<Variable> variables)
        {
            if (variables == null)
            {
                throw new ArgumentNullException("variables");
            }

            RequestId = new Integer32(requestId);
            ErrorStatus = Integer32.Zero;
            ErrorIndex = Integer32.Zero;
            Variables = variables;
            _varbindSection = Variable.Transform(Variables);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetRequestPdu"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public SetRequestPdu(EndPoint sourceEndPoint, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            RequestId = (Integer32)DataFactory.CreateSnmpData(sourceEndPoint, stream);
            ErrorStatus = (Integer32)DataFactory.CreateSnmpData(sourceEndPoint, stream);
            ErrorIndex = (Integer32)DataFactory.CreateSnmpData(sourceEndPoint, stream);
            _varbindSection = (Sequence)DataFactory.CreateSnmpData(sourceEndPoint, stream);
            Variables = Variable.Transform(_varbindSection);
        }
        
        /// <summary>
        /// Returns a <see cref="string"/> that represents this <see cref="SetRequestPdu"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "SET request PDU: seq: {0}; status: {1}; index: {2}; variable count: {3}",
                RequestId,
                ErrorStatus,
                ErrorIndex,
                Variables.Count.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the request ID.
        /// </summary>
        /// <value>The request ID.</value>
        public Integer32 RequestId { get; private set; }

        /// <summary>
        /// Gets the error status.
        /// </summary>
        /// <value>The error status.</value>
        public Integer32 ErrorStatus { get; private set; }

        /// <summary>
        /// Gets the index of the error.
        /// </summary>
        /// <value>The index of the error.</value>
        public Integer32 ErrorIndex { get; private set; }

        /// <summary>
        /// Variables.
        /// </summary>
        public IList<Variable> Variables { get; private set; }

        #region ISnmpData Members
        /// <summary>
        /// Type code.
        /// </summary>
        public SnmpType TypeCode
        {
            get { return SnmpType.SetRequestPdu; }
        }

        /// <summary>
        /// Appends the bytes to <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void AppendBytesTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            
            if (_raw == null)
            {
                _raw = ByteTool.ParseItems(RequestId, ErrorStatus, ErrorIndex, _varbindSection);
            }

            stream.AppendBytes(TypeCode, _raw);
        }

        #endregion

        //---------------------------------------
        public Type GetTypeDotNet()
        {
            return typeof(string);
        }

        //---------------------------------------
        public object ConvertToTypeDotNet()
        {
            return ToString();
        }
    }
}

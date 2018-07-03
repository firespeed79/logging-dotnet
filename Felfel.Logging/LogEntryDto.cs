﻿using System;
using Newtonsoft.Json;

namespace Felfel.Logging
{
    /// <summary>
    /// Serializable representation of a <see cref="LogEntry"/>.
    /// </summary>
    internal class LogEntryDto
    {
        internal const string DataPropertyPlaceholderName = "xxyyzz";

        [JsonProperty("@timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The context / application area where the logged
        /// message originates from. Used to simplify filtering
        /// and identification of issues in code.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Identifier that depicts the schema of the logged data.
        /// </summary>
        public string PayloadType { get; set; }

        /// <summary>
        /// Log Level.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Indicates whether exception information is available or not.
        /// This simplifies querying for actualy exceptions.
        /// </summary>
        public bool IsException => Exception != null;

        /// <summary>
        /// The actual structured payload to be serialized in JSON.
        /// <remarks>If null, is ignored. Nested null values will not be ignored
        /// by default.</remarks>
        /// </summary>
        [JsonProperty(DataPropertyPlaceholderName, NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        /// <summary>
        /// Optional exception information, if any. Not rendered in JSON if no
        /// exception was registered.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionInfo Exception { get; set; }
    }


    /// <summary>
    /// Encapsulates exception information.
    /// </summary>
    public class ExceptionInfo
    {
        /// <summary>
        /// Unqualified exception type name.
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        /// The <see cref="Exception.Message"/>.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Full stack trace.
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// A hash of the exception, built from the exception's stack
        /// trace (plus nested / hidden exceptions). Can be used
        /// to aggregate / count similar exceptions.
        /// </summary>
        public string ExceptionHash { get; set; }
    }
}
﻿using Newtonsoft.Json;
using VaultSharp.Infrastructure.JsonConverters;

namespace VaultSharp.Backends.Secret.Models.SSH
{
    /// <summary>
    /// Represents the base class for a SSH Role definition.
    /// </summary>
    [JsonConverter(typeof(SSHRoleDefinitionJsonConverter))]
    public abstract class SSHRoleDefinition
    {
        /// <summary>
        /// <para>[required]</para>
        /// Gets or sets the default username for which a credential will be generated. 
        /// When a SSH credential is requested without an explicit username, this value will be used as default username.
        /// </summary>
        /// <value>
        /// The default user.
        /// </value>
        [JsonProperty("default_user")]
        public string RoleDefaultUser { get; set; }

        /// <summary>
        /// <para>[optional]</para>
        /// Gets or sets the comma separated list of CIDR blocks for which the role is applicable for. 
        /// CIDR blocks can belong to more than one role. 
        /// Defaults to the zero address (0.0.0.0/0).
        /// </summary>
        /// <value>
        /// The CIDR values.
        /// </value>
        [JsonProperty("cidr_list")]
        public string CIDRValues { get; set; }

        /// <summary>
        /// <para>[optional]</para>
        /// Gets or sets the comma-separated list of CIDR blocks. 
        /// IP addresses belonging to these blocks are not accepted by the role. 
        /// This is particularly useful when big CIDR blocks are being used by the role and certain parts need to be kept out.
        /// </summary>
        /// <value>
        /// The exclusion CIDR values.
        /// </value>
        [JsonProperty("exclude_cidr_list")]
        public string ExcludeCIDRValues { get; set; }

        /// <summary>
        /// <para>[optional]</para>
        /// Gets or sets the port number for SSH connection. 
        /// The default is '22'. 
        /// Port number does not play any role in OTP generation. 
        /// For the 'otp' backend type, this is just a way to inform the client about the port number to use. 
        /// The port number will be returned to the client by Vault along with the OTP.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// <para>[required]</para>
        /// Type of credentials generated by this role.
        /// </summary>
        /// <value>
        /// The type of the key.
        /// </value>
        [JsonProperty("key_type")]
        public abstract SSHKeyType KeyTypeToGenerate { get; }

        /// <summary>
        /// <para>[optional]</para>
        /// Gets or sets the allowed users.
        /// If this option is not specified, a client can request credentials to log into any valid user at the remote host, including the admin user.
        ///  If this field is set, credentials can only be created for the values in this list and the value of the <see cref="RoleDefaultUser"/> field.
        /// </summary>
        /// <value>
        /// The allowed users.
        /// </value>
        [JsonProperty("allowed_users")]
        public string AllowedUsers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SSHRoleDefinition"/> class.
        /// </summary>
        protected SSHRoleDefinition()
        {
            Port = 22;
        }
    }
}
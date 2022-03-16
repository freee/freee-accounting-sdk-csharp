/*
 * freee API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Freee.Accounting.Client;
using Freee.Accounting.Models;

namespace Freee.Accounting.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IApprovalFlowRoutesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 申請経路の取得
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApprovalFlowRouteResponse</returns>
        ApprovalFlowRouteResponse GetApprovalFlowRoute(int id, int companyId);

        /// <summary>
        /// 申請経路の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of ApprovalFlowRouteResponse</returns>
        ApiResponse<ApprovalFlowRouteResponse> GetApprovalFlowRouteWithHttpInfo(int id, int companyId);
        /// <summary>
        /// 申請経路一覧の取得
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <returns>ApprovalFlowRoutesIndexResponse</returns>
        ApprovalFlowRoutesIndexResponse GetApprovalFlowRoutes(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?));

        /// <summary>
        /// 申請経路一覧の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <returns>ApiResponse of ApprovalFlowRoutesIndexResponse</returns>
        ApiResponse<ApprovalFlowRoutesIndexResponse> GetApprovalFlowRoutesWithHttpInfo(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IApprovalFlowRoutesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 申請経路の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApprovalFlowRouteResponse</returns>
        System.Threading.Tasks.Task<ApprovalFlowRouteResponse> GetApprovalFlowRouteAsync(int id, int companyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// 申請経路の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApprovalFlowRouteResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApprovalFlowRouteResponse>> GetApprovalFlowRouteWithHttpInfoAsync(int id, int companyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// 申請経路一覧の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApprovalFlowRoutesIndexResponse</returns>
        System.Threading.Tasks.Task<ApprovalFlowRoutesIndexResponse> GetApprovalFlowRoutesAsync(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// 申請経路一覧の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApprovalFlowRoutesIndexResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApprovalFlowRoutesIndexResponse>> GetApprovalFlowRoutesWithHttpInfoAsync(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IApprovalFlowRoutesApi : IApprovalFlowRoutesApiSync, IApprovalFlowRoutesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ApprovalFlowRoutesApi : IApprovalFlowRoutesApi
    {
        private Freee.Accounting.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalFlowRoutesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ApprovalFlowRoutesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalFlowRoutesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ApprovalFlowRoutesApi(string basePath)
        {
            this.Configuration = Freee.Accounting.Client.Configuration.MergeConfigurations(
                Freee.Accounting.Client.GlobalConfiguration.Instance,
                new Freee.Accounting.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Freee.Accounting.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalFlowRoutesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ApprovalFlowRoutesApi(Freee.Accounting.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Freee.Accounting.Client.Configuration.MergeConfigurations(
                Freee.Accounting.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Freee.Accounting.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalFlowRoutesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ApprovalFlowRoutesApi(Freee.Accounting.Client.ISynchronousClient client, Freee.Accounting.Client.IAsynchronousClient asyncClient, Freee.Accounting.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Freee.Accounting.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Freee.Accounting.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Freee.Accounting.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Freee.Accounting.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Freee.Accounting.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// 申請経路の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApprovalFlowRouteResponse</returns>
        public ApprovalFlowRouteResponse GetApprovalFlowRoute(int id, int companyId)
        {
            Freee.Accounting.Client.ApiResponse<ApprovalFlowRouteResponse> localVarResponse = GetApprovalFlowRouteWithHttpInfo(id, companyId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// 申請経路の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of ApprovalFlowRouteResponse</returns>
        public Freee.Accounting.Client.ApiResponse<ApprovalFlowRouteResponse> GetApprovalFlowRouteWithHttpInfo(int id, int companyId)
        {
            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));

            // authentication (oauth2) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ApprovalFlowRouteResponse>("/api/1/approval_flow_routes/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetApprovalFlowRoute", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// 申請経路の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApprovalFlowRouteResponse</returns>
        public async System.Threading.Tasks.Task<ApprovalFlowRouteResponse> GetApprovalFlowRouteAsync(int id, int companyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Freee.Accounting.Client.ApiResponse<ApprovalFlowRouteResponse> localVarResponse = await GetApprovalFlowRouteWithHttpInfoAsync(id, companyId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// 申請経路の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経路申請ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApprovalFlowRouteResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ApprovalFlowRouteResponse>> GetApprovalFlowRouteWithHttpInfoAsync(int id, int companyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));

            // authentication (oauth2) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApprovalFlowRouteResponse>("/api/1/approval_flow_routes/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetApprovalFlowRoute", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// 申請経路一覧の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <returns>ApprovalFlowRoutesIndexResponse</returns>
        public ApprovalFlowRoutesIndexResponse GetApprovalFlowRoutes(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?))
        {
            Freee.Accounting.Client.ApiResponse<ApprovalFlowRoutesIndexResponse> localVarResponse = GetApprovalFlowRoutesWithHttpInfo(companyId, includedUserId, usage, requestFormId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// 申請経路一覧の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <returns>ApiResponse of ApprovalFlowRoutesIndexResponse</returns>
        public Freee.Accounting.Client.ApiResponse<ApprovalFlowRoutesIndexResponse> GetApprovalFlowRoutesWithHttpInfo(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?))
        {
            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));
            if (includedUserId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "included_user_id", includedUserId));
            }
            if (usage != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "usage", usage));
            }
            if (requestFormId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "request_form_id", requestFormId));
            }

            // authentication (oauth2) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ApprovalFlowRoutesIndexResponse>("/api/1/approval_flow_routes", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetApprovalFlowRoutes", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// 申請経路一覧の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApprovalFlowRoutesIndexResponse</returns>
        public async System.Threading.Tasks.Task<ApprovalFlowRoutesIndexResponse> GetApprovalFlowRoutesAsync(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Freee.Accounting.Client.ApiResponse<ApprovalFlowRoutesIndexResponse> localVarResponse = await GetApprovalFlowRoutesWithHttpInfoAsync(companyId, includedUserId, usage, requestFormId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// 申請経路一覧の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="includedUserId">経路に含まれるユーザーのユーザーID (optional)</param>
        /// <param name="usage">申請種別（各申請種別が使用できる申請経路に絞り込めます。例えば、ApprovalRequest を指定すると、各種申請が使用できる申請経路に絞り込めます。） * &#x60;TxnApproval&#x60; - 仕訳承認 * &#x60;ExpenseApplication&#x60; - 経費精算 * &#x60;PaymentRequest&#x60; - 支払依頼 * &#x60;ApprovalRequest&#x60; - 各種申請 * &#x60;DocApproval&#x60; - 請求書等 (見積書・納品書・請求書・発注書) (optional)</param>
        /// <param name="requestFormId">申請フォームID request_form_id指定時はusage条件をApprovalRequestに指定してください。指定しない場合無効になります。 (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApprovalFlowRoutesIndexResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ApprovalFlowRoutesIndexResponse>> GetApprovalFlowRoutesWithHttpInfoAsync(int companyId, int? includedUserId = default(int?), string usage = default(string), int? requestFormId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));
            if (includedUserId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "included_user_id", includedUserId));
            }
            if (usage != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "usage", usage));
            }
            if (requestFormId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "request_form_id", requestFormId));
            }

            // authentication (oauth2) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApprovalFlowRoutesIndexResponse>("/api/1/approval_flow_routes", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetApprovalFlowRoutes", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}

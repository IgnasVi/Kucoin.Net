﻿using CryptoExchange.Net.Objects;
using Kucoin.Net.Enums;
using Kucoin.Net.Objects.Models;
using Kucoin.Net.Objects.Models.Futures;
using Kucoin.Net.Objects.Models.Spot;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kucoin.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Margin borrow and repay endpoints
    /// </summary>
    public interface IKucoinRestClientSpotApiMargin
    {
        /// <summary>
        /// Get margin configuration
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-info/get-margin-configuration-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinMarginConfig>> GetMarginConfigurationAsync(CancellationToken ct = default);

        /// <summary>
        /// Get the mark price of a symbol
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-info/get-mark-price" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to retrieve</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinIndexBase>> GetMarginMarkPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get Margin Trading Pair ConfigurationAsync
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/isolated-margin/get-isolated-margin-symbols-configuration" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param> 
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<KucoinTradingPairConfiguration>>> GetMarginTradingPairConfigurationAsync(CancellationToken ct = default);

        /// <summary>
        /// Get cross margin risk limit and asset configuration info
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-info/get-cross-isolated-margin-risk-limit-currency-config" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param> 
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<KucoinCrossRiskLimitConfig>>> GetCrossMarginRiskLimitAndConfig(CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin risk limit and asset configuration info
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-info/get-cross-isolated-margin-risk-limit-currency-config" /></para>
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param> 
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<KucoinIsolatedRiskLimitConfig>>> GetIsolatedMarginRiskLimitAndConfig(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Borrow an asset
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-trading-v3-/margin-borrowing" /></para>
        /// </summary>
        /// <param name="asset">Currency to Borrow e.g USDT etc</param>
        /// <param name="timeInForce">Time in force (FOK, IOC)</param>
        /// <param name="quantity">Total size</param>
        /// <param name="isIsolated">If isolated margin</param>
        /// <param name="symbol">Isolated margin symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The id of the new order</returns>
        Task<WebCallResult<KucoinNewBorrowOrder>> BorrowAsync(
           string asset,
            TimeInForce timeInForce,
            decimal quantity,
            bool? isIsolated = null,
            string? symbol = null,
           CancellationToken ct = default);

        /// <summary>
        /// Repayment for previously borrowed asset
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-trading-v3-/repayment" /></para>
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="quantity"></param>
        /// <param name="isIsolated"></param>
        /// <param name="symbol"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<WebCallResult<KucoinNewBorrowOrder>> RepayAsync(
            string asset,
            decimal quantity,
            bool? isIsolated = null,
            string? symbol = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get borrow history
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-trading-v3-/get-margin-borrowing-history" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="isIsolated">Filter by is isolated margin</param>
        /// <param name="symbol">Filter by isolated margin symbol</param>
        /// <param name="orderId">Filter by borrow order number</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">The page to retrieve</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinPaginated<KucoinBorrowOrderV3>>> GetBorrowHistoryAsync(string asset, bool? isIsolated = null, string? symbol = null, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get repayment history
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-trading-v3-/get-margin-borrowing-history" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="isIsolated">Filter by is isolated margin</param>
        /// <param name="symbol">Filter by isolated margin symbol</param>
        /// <param name="orderId">Filter by repay order number</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">The page to retrieve</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinPaginated<KucoinBorrowOrderV3>>> GetRepayHistoryAsync(string asset, bool? isIsolated = null, string? symbol = null, string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get margin interest records
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/margin-trading-v3-/get-cross-isolated-margin-interest-records" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="isIsolated">Filter by is isolated margin</param>
        /// <param name="symbol">Filter by isolated margin symbol</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">The page to retrieve</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinPaginated<KucoinMarginInterest>>> GetInterestHistoryAsync(string asset, bool? isIsolated = null, string? symbol = null, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get lending asset info
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/lending-market-v3-/get-currency-information" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<KucoinLendingAsset>>> GetLendingAssetsAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get lending interest rates
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/lending-market-v3-/get-interest-rates" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<KucoinLendingInterest>>> GetInterestRatesAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Initiate subscriptions of margin lending
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/lending-market-v3-/subscription" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="interestRate">Interest rate</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinLendingResult>> SubscribeAsync(string asset, decimal quantity, decimal interestRate, CancellationToken ct = default);

        /// <summary>
        /// Initiate redemptions of margin lending.
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/lending-market-v3-/redemption" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="subscribeOrderId">Subscribe order number</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinLendingResult>> RedeemAsync(string asset, decimal quantity, string subscribeOrderId, CancellationToken ct = default);

        /// <summary>
        /// Update interest rate of a subscription order
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/lending-market-v3-/modify-subscription-orders" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="interestRate">New interest rate</param>
        /// <param name="subscribeOrderId">Subscribe order number</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> EditSubscriptionOrderAsync(string asset, decimal interestRate, string subscribeOrderId, CancellationToken ct = default);

        /// <summary>
        /// Get redemption orders
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/lending-market-v3-/get-redemption-orders" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="redeemOrderId">Filter by redeem order id</param>
        /// <param name="status">Status, DONE or PENDING</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinPaginated<KucoinRedemption>>> GetRedemptionOrdersAsync(string asset, string status, string? redeemOrderId = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get subscription orders
        /// <para><a href="https://www.kucoin.com/docs/rest/margin-trading/lending-market-v3-/get-subscription-orders" /></para>
        /// </summary>
        /// <param name="asset">Asset</param>
        /// <param name="status">Status, DONE or PENDING</param>
        /// <param name="purchaseOrderId">Filter by purchase order id</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<KucoinPaginated<KucoinLendSubscription>>> GetSubscriptionOrdersAsync(string asset, string status, string? purchaseOrderId = null, int? page = null, int? pageSize = null, CancellationToken ct = default);
    }
}
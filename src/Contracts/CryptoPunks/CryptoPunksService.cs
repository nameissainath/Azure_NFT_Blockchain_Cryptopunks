using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using NftBot.Contracts.CryptoPunks.ContractDefinition;

namespace NftBot.Contracts.CryptoPunks
{
    public partial class CryptoPunksService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CryptoPunksDeployment cryptoPunksDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CryptoPunksDeployment>().SendRequestAndWaitForReceiptAsync(cryptoPunksDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CryptoPunksDeployment cryptoPunksDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CryptoPunksDeployment>().SendRequestAsync(cryptoPunksDeployment);
        }

        public static async Task<CryptoPunksService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CryptoPunksDeployment cryptoPunksDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, cryptoPunksDeployment, cancellationTokenSource);
            return new CryptoPunksService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CryptoPunksService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<PunksOfferedForSaleOutputDTO> PunksOfferedForSaleQueryAsync(PunksOfferedForSaleFunction punksOfferedForSaleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PunksOfferedForSaleFunction, PunksOfferedForSaleOutputDTO>(punksOfferedForSaleFunction, blockParameter);
        }

        public Task<PunksOfferedForSaleOutputDTO> PunksOfferedForSaleQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var punksOfferedForSaleFunction = new PunksOfferedForSaleFunction();
                punksOfferedForSaleFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PunksOfferedForSaleFunction, PunksOfferedForSaleOutputDTO>(punksOfferedForSaleFunction, blockParameter);
        }

        public Task<string> EnterBidForPunkRequestAsync(EnterBidForPunkFunction enterBidForPunkFunction)
        {
             return ContractHandler.SendRequestAsync(enterBidForPunkFunction);
        }

        public Task<TransactionReceipt> EnterBidForPunkRequestAndWaitForReceiptAsync(EnterBidForPunkFunction enterBidForPunkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(enterBidForPunkFunction, cancellationToken);
        }

        public Task<string> EnterBidForPunkRequestAsync(BigInteger punkIndex)
        {
            var enterBidForPunkFunction = new EnterBidForPunkFunction();
                enterBidForPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAsync(enterBidForPunkFunction);
        }

        public Task<TransactionReceipt> EnterBidForPunkRequestAndWaitForReceiptAsync(BigInteger punkIndex, CancellationTokenSource cancellationToken = null)
        {
            var enterBidForPunkFunction = new EnterBidForPunkFunction();
                enterBidForPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(enterBidForPunkFunction, cancellationToken);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> AcceptBidForPunkRequestAsync(AcceptBidForPunkFunction acceptBidForPunkFunction)
        {
             return ContractHandler.SendRequestAsync(acceptBidForPunkFunction);
        }

        public Task<TransactionReceipt> AcceptBidForPunkRequestAndWaitForReceiptAsync(AcceptBidForPunkFunction acceptBidForPunkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(acceptBidForPunkFunction, cancellationToken);
        }

        public Task<string> AcceptBidForPunkRequestAsync(BigInteger punkIndex, BigInteger minPrice)
        {
            var acceptBidForPunkFunction = new AcceptBidForPunkFunction();
                acceptBidForPunkFunction.PunkIndex = punkIndex;
                acceptBidForPunkFunction.MinPrice = minPrice;
            
             return ContractHandler.SendRequestAsync(acceptBidForPunkFunction);
        }

        public Task<TransactionReceipt> AcceptBidForPunkRequestAndWaitForReceiptAsync(BigInteger punkIndex, BigInteger minPrice, CancellationTokenSource cancellationToken = null)
        {
            var acceptBidForPunkFunction = new AcceptBidForPunkFunction();
                acceptBidForPunkFunction.PunkIndex = punkIndex;
                acceptBidForPunkFunction.MinPrice = minPrice;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(acceptBidForPunkFunction, cancellationToken);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> SetInitialOwnersRequestAsync(SetInitialOwnersFunction setInitialOwnersFunction)
        {
             return ContractHandler.SendRequestAsync(setInitialOwnersFunction);
        }

        public Task<TransactionReceipt> SetInitialOwnersRequestAndWaitForReceiptAsync(SetInitialOwnersFunction setInitialOwnersFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialOwnersFunction, cancellationToken);
        }

        public Task<string> SetInitialOwnersRequestAsync(List<string> addresses, List<BigInteger> indices)
        {
            var setInitialOwnersFunction = new SetInitialOwnersFunction();
                setInitialOwnersFunction.Addresses = addresses;
                setInitialOwnersFunction.Indices = indices;
            
             return ContractHandler.SendRequestAsync(setInitialOwnersFunction);
        }

        public Task<TransactionReceipt> SetInitialOwnersRequestAndWaitForReceiptAsync(List<string> addresses, List<BigInteger> indices, CancellationTokenSource cancellationToken = null)
        {
            var setInitialOwnersFunction = new SetInitialOwnersFunction();
                setInitialOwnersFunction.Addresses = addresses;
                setInitialOwnersFunction.Indices = indices;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialOwnersFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<string> WithdrawRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawFunction>();
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }

        public Task<string> ImageHashQueryAsync(ImageHashFunction imageHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ImageHashFunction, string>(imageHashFunction, blockParameter);
        }

        
        public Task<string> ImageHashQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ImageHashFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> NextPunkIndexToAssignQueryAsync(NextPunkIndexToAssignFunction nextPunkIndexToAssignFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextPunkIndexToAssignFunction, BigInteger>(nextPunkIndexToAssignFunction, blockParameter);
        }

        
        public Task<BigInteger> NextPunkIndexToAssignQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextPunkIndexToAssignFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> PunkIndexToAddressQueryAsync(PunkIndexToAddressFunction punkIndexToAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PunkIndexToAddressFunction, string>(punkIndexToAddressFunction, blockParameter);
        }

        
        public Task<string> PunkIndexToAddressQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var punkIndexToAddressFunction = new PunkIndexToAddressFunction();
                punkIndexToAddressFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<PunkIndexToAddressFunction, string>(punkIndexToAddressFunction, blockParameter);
        }

        public Task<string> StandardQueryAsync(StandardFunction standardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StandardFunction, string>(standardFunction, blockParameter);
        }

        
        public Task<string> StandardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StandardFunction, string>(null, blockParameter);
        }

        public Task<PunkBidsOutputDTO> PunkBidsQueryAsync(PunkBidsFunction punkBidsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PunkBidsFunction, PunkBidsOutputDTO>(punkBidsFunction, blockParameter);
        }

        public Task<PunkBidsOutputDTO> PunkBidsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var punkBidsFunction = new PunkBidsFunction();
                punkBidsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PunkBidsFunction, PunkBidsOutputDTO>(punkBidsFunction, blockParameter);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> AllInitialOwnersAssignedRequestAsync(AllInitialOwnersAssignedFunction allInitialOwnersAssignedFunction)
        {
             return ContractHandler.SendRequestAsync(allInitialOwnersAssignedFunction);
        }

        public Task<string> AllInitialOwnersAssignedRequestAsync()
        {
             return ContractHandler.SendRequestAsync<AllInitialOwnersAssignedFunction>();
        }

        public Task<TransactionReceipt> AllInitialOwnersAssignedRequestAndWaitForReceiptAsync(AllInitialOwnersAssignedFunction allInitialOwnersAssignedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(allInitialOwnersAssignedFunction, cancellationToken);
        }

        public Task<TransactionReceipt> AllInitialOwnersAssignedRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<AllInitialOwnersAssignedFunction>(null, cancellationToken);
        }

        public Task<bool> AllPunksAssignedQueryAsync(AllPunksAssignedFunction allPunksAssignedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllPunksAssignedFunction, bool>(allPunksAssignedFunction, blockParameter);
        }

        
        public Task<bool> AllPunksAssignedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllPunksAssignedFunction, bool>(null, blockParameter);
        }

        public Task<string> BuyPunkRequestAsync(BuyPunkFunction buyPunkFunction)
        {
             return ContractHandler.SendRequestAsync(buyPunkFunction);
        }

        public Task<TransactionReceipt> BuyPunkRequestAndWaitForReceiptAsync(BuyPunkFunction buyPunkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyPunkFunction, cancellationToken);
        }

        public Task<string> BuyPunkRequestAsync(BigInteger punkIndex)
        {
            var buyPunkFunction = new BuyPunkFunction();
                buyPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAsync(buyPunkFunction);
        }

        public Task<TransactionReceipt> BuyPunkRequestAndWaitForReceiptAsync(BigInteger punkIndex, CancellationTokenSource cancellationToken = null)
        {
            var buyPunkFunction = new BuyPunkFunction();
                buyPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyPunkFunction, cancellationToken);
        }

        public Task<string> TransferPunkRequestAsync(TransferPunkFunction transferPunkFunction)
        {
             return ContractHandler.SendRequestAsync(transferPunkFunction);
        }

        public Task<TransactionReceipt> TransferPunkRequestAndWaitForReceiptAsync(TransferPunkFunction transferPunkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferPunkFunction, cancellationToken);
        }

        public Task<string> TransferPunkRequestAsync(string to, BigInteger punkIndex)
        {
            var transferPunkFunction = new TransferPunkFunction();
                transferPunkFunction.To = to;
                transferPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAsync(transferPunkFunction);
        }

        public Task<TransactionReceipt> TransferPunkRequestAndWaitForReceiptAsync(string to, BigInteger punkIndex, CancellationTokenSource cancellationToken = null)
        {
            var transferPunkFunction = new TransferPunkFunction();
                transferPunkFunction.To = to;
                transferPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferPunkFunction, cancellationToken);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<string> WithdrawBidForPunkRequestAsync(WithdrawBidForPunkFunction withdrawBidForPunkFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawBidForPunkFunction);
        }

        public Task<TransactionReceipt> WithdrawBidForPunkRequestAndWaitForReceiptAsync(WithdrawBidForPunkFunction withdrawBidForPunkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawBidForPunkFunction, cancellationToken);
        }

        public Task<string> WithdrawBidForPunkRequestAsync(BigInteger punkIndex)
        {
            var withdrawBidForPunkFunction = new WithdrawBidForPunkFunction();
                withdrawBidForPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAsync(withdrawBidForPunkFunction);
        }

        public Task<TransactionReceipt> WithdrawBidForPunkRequestAndWaitForReceiptAsync(BigInteger punkIndex, CancellationTokenSource cancellationToken = null)
        {
            var withdrawBidForPunkFunction = new WithdrawBidForPunkFunction();
                withdrawBidForPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawBidForPunkFunction, cancellationToken);
        }

        public Task<string> SetInitialOwnerRequestAsync(SetInitialOwnerFunction setInitialOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(setInitialOwnerFunction);
        }

        public Task<TransactionReceipt> SetInitialOwnerRequestAndWaitForReceiptAsync(SetInitialOwnerFunction setInitialOwnerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialOwnerFunction, cancellationToken);
        }

        public Task<string> SetInitialOwnerRequestAsync(string to, BigInteger punkIndex)
        {
            var setInitialOwnerFunction = new SetInitialOwnerFunction();
                setInitialOwnerFunction.To = to;
                setInitialOwnerFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAsync(setInitialOwnerFunction);
        }

        public Task<TransactionReceipt> SetInitialOwnerRequestAndWaitForReceiptAsync(string to, BigInteger punkIndex, CancellationTokenSource cancellationToken = null)
        {
            var setInitialOwnerFunction = new SetInitialOwnerFunction();
                setInitialOwnerFunction.To = to;
                setInitialOwnerFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInitialOwnerFunction, cancellationToken);
        }

        public Task<string> OfferPunkForSaleToAddressRequestAsync(OfferPunkForSaleToAddressFunction offerPunkForSaleToAddressFunction)
        {
             return ContractHandler.SendRequestAsync(offerPunkForSaleToAddressFunction);
        }

        public Task<TransactionReceipt> OfferPunkForSaleToAddressRequestAndWaitForReceiptAsync(OfferPunkForSaleToAddressFunction offerPunkForSaleToAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(offerPunkForSaleToAddressFunction, cancellationToken);
        }

        public Task<string> OfferPunkForSaleToAddressRequestAsync(BigInteger punkIndex, BigInteger minSalePriceInWei, string toAddress)
        {
            var offerPunkForSaleToAddressFunction = new OfferPunkForSaleToAddressFunction();
                offerPunkForSaleToAddressFunction.PunkIndex = punkIndex;
                offerPunkForSaleToAddressFunction.MinSalePriceInWei = minSalePriceInWei;
                offerPunkForSaleToAddressFunction.ToAddress = toAddress;
            
             return ContractHandler.SendRequestAsync(offerPunkForSaleToAddressFunction);
        }

        public Task<TransactionReceipt> OfferPunkForSaleToAddressRequestAndWaitForReceiptAsync(BigInteger punkIndex, BigInteger minSalePriceInWei, string toAddress, CancellationTokenSource cancellationToken = null)
        {
            var offerPunkForSaleToAddressFunction = new OfferPunkForSaleToAddressFunction();
                offerPunkForSaleToAddressFunction.PunkIndex = punkIndex;
                offerPunkForSaleToAddressFunction.MinSalePriceInWei = minSalePriceInWei;
                offerPunkForSaleToAddressFunction.ToAddress = toAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(offerPunkForSaleToAddressFunction, cancellationToken);
        }

        public Task<BigInteger> PunksRemainingToAssignQueryAsync(PunksRemainingToAssignFunction punksRemainingToAssignFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PunksRemainingToAssignFunction, BigInteger>(punksRemainingToAssignFunction, blockParameter);
        }

        
        public Task<BigInteger> PunksRemainingToAssignQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PunksRemainingToAssignFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OfferPunkForSaleRequestAsync(OfferPunkForSaleFunction offerPunkForSaleFunction)
        {
             return ContractHandler.SendRequestAsync(offerPunkForSaleFunction);
        }

        public Task<TransactionReceipt> OfferPunkForSaleRequestAndWaitForReceiptAsync(OfferPunkForSaleFunction offerPunkForSaleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(offerPunkForSaleFunction, cancellationToken);
        }

        public Task<string> OfferPunkForSaleRequestAsync(BigInteger punkIndex, BigInteger minSalePriceInWei)
        {
            var offerPunkForSaleFunction = new OfferPunkForSaleFunction();
                offerPunkForSaleFunction.PunkIndex = punkIndex;
                offerPunkForSaleFunction.MinSalePriceInWei = minSalePriceInWei;
            
             return ContractHandler.SendRequestAsync(offerPunkForSaleFunction);
        }

        public Task<TransactionReceipt> OfferPunkForSaleRequestAndWaitForReceiptAsync(BigInteger punkIndex, BigInteger minSalePriceInWei, CancellationTokenSource cancellationToken = null)
        {
            var offerPunkForSaleFunction = new OfferPunkForSaleFunction();
                offerPunkForSaleFunction.PunkIndex = punkIndex;
                offerPunkForSaleFunction.MinSalePriceInWei = minSalePriceInWei;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(offerPunkForSaleFunction, cancellationToken);
        }

        public Task<string> GetPunkRequestAsync(GetPunkFunction getPunkFunction)
        {
             return ContractHandler.SendRequestAsync(getPunkFunction);
        }

        public Task<TransactionReceipt> GetPunkRequestAndWaitForReceiptAsync(GetPunkFunction getPunkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(getPunkFunction, cancellationToken);
        }

        public Task<string> GetPunkRequestAsync(BigInteger punkIndex)
        {
            var getPunkFunction = new GetPunkFunction();
                getPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAsync(getPunkFunction);
        }

        public Task<TransactionReceipt> GetPunkRequestAndWaitForReceiptAsync(BigInteger punkIndex, CancellationTokenSource cancellationToken = null)
        {
            var getPunkFunction = new GetPunkFunction();
                getPunkFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(getPunkFunction, cancellationToken);
        }

        public Task<BigInteger> PendingWithdrawalsQueryAsync(PendingWithdrawalsFunction pendingWithdrawalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingWithdrawalsFunction, BigInteger>(pendingWithdrawalsFunction, blockParameter);
        }

        
        public Task<BigInteger> PendingWithdrawalsQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var pendingWithdrawalsFunction = new PendingWithdrawalsFunction();
                pendingWithdrawalsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<PendingWithdrawalsFunction, BigInteger>(pendingWithdrawalsFunction, blockParameter);
        }

        public Task<string> PunkNoLongerForSaleRequestAsync(PunkNoLongerForSaleFunction punkNoLongerForSaleFunction)
        {
             return ContractHandler.SendRequestAsync(punkNoLongerForSaleFunction);
        }

        public Task<TransactionReceipt> PunkNoLongerForSaleRequestAndWaitForReceiptAsync(PunkNoLongerForSaleFunction punkNoLongerForSaleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(punkNoLongerForSaleFunction, cancellationToken);
        }

        public Task<string> PunkNoLongerForSaleRequestAsync(BigInteger punkIndex)
        {
            var punkNoLongerForSaleFunction = new PunkNoLongerForSaleFunction();
                punkNoLongerForSaleFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAsync(punkNoLongerForSaleFunction);
        }

        public Task<TransactionReceipt> PunkNoLongerForSaleRequestAndWaitForReceiptAsync(BigInteger punkIndex, CancellationTokenSource cancellationToken = null)
        {
            var punkNoLongerForSaleFunction = new PunkNoLongerForSaleFunction();
                punkNoLongerForSaleFunction.PunkIndex = punkIndex;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(punkNoLongerForSaleFunction, cancellationToken);
        }
    }
}

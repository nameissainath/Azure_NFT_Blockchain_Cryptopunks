using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Nethereum.Web3;
using NftBot.Contracts.CryptoPunks;
using NftBot.Contracts.CryptoPunks.ContractDefinition;

namespace NftBot.Bots
{
  public class NftBot : ActivityHandler
  {
    private const int LowerIndexBound = 0;
    private const int UpperIndexBound = 9999;

    private readonly CryptoPunksService _cryptoPunksService;

    public NftBot(CryptoPunksService cryptoPunksService)
    {
      _cryptoPunksService = cryptoPunksService;
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
      var punkIndex = BigInteger.Parse(turnContext.Activity.Text);
      var punkIndexValid = punkIndex >= LowerIndexBound && punkIndex <= UpperIndexBound;

      var replyText = !punkIndexValid
        ? "Please use punk indexes between 0 and 9999"
        : await ProcessSaleOfferResult(punkIndex);

      await turnContext.SendActivityAsync(MessageFactory.Text(replyText), cancellationToken);
    }

    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
    {
      var welcomeText = "Hello and welcome!";
      foreach (var member in membersAdded)
      {
        if (member.Id != turnContext.Activity.Recipient.Id)
        {
          await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
        }
      }
    }

    private async Task<string> ProcessSaleOfferResult(BigInteger punkIndex)
    {
      var result = await _cryptoPunksService.PunksOfferedForSaleQueryAsync(punkIndex);

      if (!result.IsForSale)
      {
        return $"Punk {result.PunkIndex} is not for sale!";
      }

      var replyBuilder = new StringBuilder();

      replyBuilder.AppendLine($"Punk {result.PunkIndex} is for sale!");
      replyBuilder.AppendLine($"By seller {result.Seller}");
      replyBuilder.AppendLine($"With a minimum value of {Web3.Convert.FromWei(result.MinValue)} ETH");

      return replyBuilder.ToString();
    }
  }
}
using JuegoBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoBlazor.Pages
{
    public partial class BlazeMemory
    {
        List<CardModel> Cards = new List<CardModel>
        {
            new CardModel
            {
                FrontPath = "/img/alicia.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/alicia.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/Jorge.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/Jorge.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/Juaquin.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/Juaquin.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/luis.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/luis.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/tina.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/tina.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/Raul.jpg",
                BackPath = "/img/esm.jpg"
            },
            new CardModel
            {
                FrontPath = "/img/Raul.jpg",
                BackPath = "/img/esm.jpg"
            }
        };

        bool hasFlippedCard = false;

        CardModel firstCard;
        CardModel secondCard;

        bool lockBoard = false;
        private async Task CheckCards(CardModel cardModel)
        {
            if (lockBoard)
            {
                return;
            }

            if(cardModel == firstCard)
            {
                return;
            }

            cardModel.IsFlipped = true;

            if (!hasFlippedCard)
            {
                hasFlippedCard = true;
                firstCard = cardModel;
                return;
            }
            
            
                //hasFlippedCard = false;
                secondCard = cardModel;

                await CheckForMatch();
               
                Console.WriteLine("Execute");
                //Console.WriteLine($"{firstCard.FrontPath}, {secondCard.FrontPath}");
            
        }
        private async Task CheckForMatch()
        {
            if (firstCard.FrontPath == secondCard.FrontPath)
            {
                DisableCards();
            }
            else
            {
                await UnFlipCards();
            }
        }
        private void DisableCards()
        {
            firstCard.CanExecute = false;
            secondCard.CanExecute = false;

            ResetBoard();
        }

        private async Task UnFlipCards()
        {
            lockBoard = true;
            await Task.Delay(1500);
            firstCard.IsFlipped = false;
            secondCard.IsFlipped = false;
            lockBoard = false;
            ResetBoard();
        }

        private void ResetBoard()
        {
            hasFlippedCard = false;
            lockBoard = false;
            firstCard = new CardModel();
            secondCard = new CardModel();
        }

        protected override void OnInitialized()
        {
            Shuffle();
        }

        private void Shuffle()
        {
            foreach(var c in Cards)
            {
                c.Order = new Random().Next(0, 1000);
            }
        }
    }
}

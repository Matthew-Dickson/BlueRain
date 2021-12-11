using Microsoft.AspNetCore.Mvc;
using MTGBacked.Models;
using System.Collections.Generic;
using System.Linq;

namespace MTGBacked.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicTheGatheringCardsController : ControllerBase
    {
        private readonly MagicTheGatheringCardDbContext _context;
        public MagicTheGatheringCardsController(MagicTheGatheringCardDbContext context)
        {
            _context = context;
        }

        // Returns the list of magic cards 
        [HttpGet]
        public List<MagicTheGatheringCard> GetCards()
        {
            return _context.MagicTheGatheringCards.ToList();
        }

        // Returns the a single magic card
        [HttpGet("{id}")]
        public MagicTheGatheringCard GetCardById(int id)
        {
            return _context.MagicTheGatheringCards.SingleOrDefault(card => card.Id == id);
        }

        // Deletes a magic card from the DB
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            MagicTheGatheringCard cardToDelete = _context.MagicTheGatheringCards.SingleOrDefault(card => card.Id == id);
            if(cardToDelete == null)
            {
                return NotFound("Card with Id " + id + " not found");
            }
            _context.MagicTheGatheringCards.Remove(cardToDelete);
            _context.SaveChanges();
            return Ok("card with Id " + id + " deleted");
        }

        // Adds a magic card
        [HttpPost]
        public IActionResult AddCard(MagicTheGatheringCard card)
        {
            _context.MagicTheGatheringCards.Add(card);
            _context.SaveChanges();
            return Created("api/cards/" + card.Id, card);

        }

        // Updates a magic card
        [HttpPut("{id}")]
        public IActionResult Update(int id, MagicTheGatheringCard card)
        {
            MagicTheGatheringCard cardToUpdate = _context.MagicTheGatheringCards.SingleOrDefault(card => card.Id == id);
            if (cardToUpdate == null)
            {
                return NotFound("Card with Id " + id + " not found");
            }
            if(card.CardName != null)
            {
                cardToUpdate.CardName = card.CardName;
            }
            if (card.CardType != null)
            {
                cardToUpdate.CardType = card.CardType;
            }
            _context.Update(cardToUpdate);
            _context.SaveChanges();
            return Ok("Card with Id " + id + " updated");
        }



    }
}

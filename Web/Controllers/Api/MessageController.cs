using PersistenceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using PersistenceLayer.IRepositories;
using Microsoft.AspNet.Identity;

namespace Web.Controllers.Api
{
    public class MessageController : ApiController
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUsersRepository _usersRepository;
        public MessageController(IMessageRepository messageRepository,
            IUsersRepository usersRepository) {
            _messageRepository = messageRepository;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll() {
            return Ok(await _messageRepository.GetAll());
        }
        [HttpPost]
        public async Task<IHttpActionResult> PostMessage(MessageDto model) {
            var userName = User.Identity.GetUserName();

            var message = await _messageRepository.PostMessage(model);

            await _usersRepository.PostUserPhone(userName, message.Phone);

            return Ok(message);
        }
    }
}
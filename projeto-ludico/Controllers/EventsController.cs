using projeto_ludico.Models;
using System;
using System.Data;

namespace projeto_ludico.Controllers
{
    public class EventsController
    {
        private EventsRepository _repository;

        public EventsController()
        {
            _repository = new EventsRepository();
        }

        public void CreateEvent(EventsModel eventsModel)
        {
            if (string.IsNullOrEmpty(eventsModel.name))
                throw new ArgumentException("Nome do evento é obrigatório.");

            if (eventsModel.date < DateTime.Now)
                throw new ArgumentException("Data do evento deve ser futura.");

            if (eventsModel.id_local <= 0)
                throw new ArgumentException("Local do evento é obrigatório.");

            eventsModel.created_at = DateTime.Now;
            eventsModel.status = "Ativo";
            
            _repository.AddEvent(eventsModel);
        }

        public void UpdateEvent(EventsModel eventsModel)
        {
            if (string.IsNullOrEmpty(eventsModel.name))
                throw new ArgumentException("Nome do evento é obrigatório.");

            if (eventsModel.date < DateTime.Now)
                throw new ArgumentException("Data do evento deve ser futura.");

            if (eventsModel.id_local <= 0)
                throw new ArgumentException("Local do evento é obrigatório.");

            eventsModel.updated_at = DateTime.Now;
            
            _repository.UpdateEvent(eventsModel);
        }

        public void DeleteEvent(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID do evento inválido.");

            _repository.DeleteEvent(id);
        }

        public DataTable GetAllEvents()
        {
            return _repository.GetAllEvents();
        }

        public DataTable SearchEvents(string searchTerm)
        {
            return _repository.SearchEvents(searchTerm);
        }

        public EventsModel GetEventById(int id)
        {
            return _repository.GetEventById(id);
        }
    }
} 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace projeto_ludico.Repository
{
    internal class BoardGamesListRepository
    {
        public void AddGameToList(int id_list, int id_board_game)
        {
            using (var context = new AppDbContext())
            {
                 // Verifica se o jogo já existe na lista para evitar duplicidade
                bool exists = context.BoardGamesList.Any(bg => bg.id_list == id_list && bg.id_board_game == id_board_game);

                if (exists) {
                    throw new Exception("Jogo a ser adicionado já está na lista.");
                }

                var existingGame = context.BoardGames.Find(id_board_game); // Anexar o jogo existente

                if (existingGame == null) {
                    throw new Exception("Jogo a ser removido não foi encontrado.");
                }

                // Cria nova entrada na lista de jogos com o jogo existente
                var boardGameList = new BoardGamesListModel
                {
                    id_list = id_list,
                    id_board_game = id_board_game,
                    boardGames = existingGame
                };

                context.BoardGamesList.Add(boardGameList);
                context.SaveChanges();
            }
        }

        // Remove um jogo específico de uma lista, com base no ID da lista e ID do item.
        public void RemoveGameFromList(int id_list, int id)
        {
            using (var context = new AppDbContext())
            {
                var entity = context.BoardGamesList.FirstOrDefault(bg => bg.id_list == id_list && bg.id == id);

                if (entity != null) {
                    context.BoardGamesList.Remove(entity);
                    context.SaveChanges();
                }

                else {
                    throw new Exception($"Jogo a ser removido não foi encontrado na lista.");
                }
            }
        }

        // Retorna uma lista de tuplas contendo o ID e o nome principal de cada jogo associado a uma lista específica.
        public List<(int id, string main_name)> GetGamesByListId(int id_list)
        {
            using (var context = new AppDbContext())
            {
                var query = context.BoardGamesList
                    .Where(bgList => bgList.id_list == id_list)
                    .Include(bgList => bgList.boardGames.names)
                    .Select(bgList => new
                    {
                        id = bgList.id,
                        main_name = bgList.boardGames.names
                            .Where(n => n.is_principal)
                            .Select(n => n.name)
                            .FirstOrDefault()
                            ?? bgList.boardGames.names.Select(n => n.name).FirstOrDefault() // fallback
                    });

                // Converte para tuplas na memória
                var result = query
                    .AsEnumerable() // Move a execução para a memória
                    .Select(x => (x.id, x.main_name))
                    .ToList();

                return result;
            }
        }




    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using projeto_ludico.Models;

namespace projeto_ludico.Repository
{
    internal class BoardGamesRepository
    {
        public void AddBoardGames(BoardGamesModel boardGameModel)
        {
            using (var context = new AppDbContext())
            {
                context.BoardGames.Add(boardGameModel);
                context.SaveChanges();
            }
        }

        //Funcionamento basicamente identico com a função acima, única diferença seria a query do SQL, que é um Update
        public void UpdateBoardGames(BoardGamesModel updatedBoardGame)
        {
            using (var context = new AppDbContext())
            {
                var existingBoardGame = context.BoardGames
                    .Include(bg => bg.names)
                    .Include(bg => bg.codes)
                    .FirstOrDefault(bg => bg.id == updatedBoardGame.id);

                if (existingBoardGame == null)
                    throw new InvalidOperationException("Jogo de tabuleiro não encontrado.");

                // Atualiza campos simples
                existingBoardGame.description = updatedBoardGame.description;
                existingBoardGame.min_players = updatedBoardGame.min_players;
                existingBoardGame.max_players = updatedBoardGame.max_players;
                existingBoardGame.game_time = updatedBoardGame.game_time;
                existingBoardGame.year = updatedBoardGame.year;

                // Remove os filhos explicitamente do contexto
                context.BoardGamesNames.RemoveRange(existingBoardGame.names);
                context.BoardGamesBarCodes.RemoveRange(existingBoardGame.codes);

                // Salva para aplicar remoção dos filhos
                context.SaveChanges();

                // Adiciona os novos filhos, com FK correta
                foreach (var name in updatedBoardGame.names)
                {
                    name.id_board_game = existingBoardGame.id;
                    context.BoardGamesNames.Add(name);
                }

                foreach (var code in updatedBoardGame.codes)
                {
                    code.id_board_game = existingBoardGame.id;
                    context.BoardGamesBarCodes.Add(code);
                }

                // Salva as mudanças finais
                context.SaveChanges();
            }
        }



        //Realiza a deleção do participante pelo Id na query
        public void DeleteBoardGames(int id)
        {
            using (var context = new AppDbContext())
            {
                // Busca o jogo pelo ID
                var boardGame = context.BoardGames.SingleOrDefault(b => b.id == id);

                if (boardGame == null)
                {
                    throw new KeyNotFoundException($"Nenhum jogo encontrado com o ID {id}.");
                }

                // Remove o jogo do contexto
                context.BoardGames.Remove(boardGame);

                // Salva as alterações no banco de dados
                context.SaveChanges();
            }
        }

        //Retorna todas as informações do ParticipantModel a partir do SELECT filtrado pelo id no parâmetro
        public BoardGamesModel GetBoardGamesById(int id)
        {
            using (var context = new AppDbContext())
            {
                // Busca o jogo pelo ID com as listas relacionadas
                var boardGame = context.BoardGames
                    .Include(b => b.names)
                    .Include(b => b.codes)
                    .SingleOrDefault(b => b.id == id);

                if (boardGame == null)
                {
                    throw new KeyNotFoundException($"Nenhum jogo encontrado com o ID {id}.");
                }

                return boardGame;
            }
        }

        public List<object> GetAllGamesWithMainName()
        {
            using (var context = new AppDbContext())
            {
                var games = context.BoardGames
                    .Select(bg => new
                    {
                        ID = bg.id,
                        NomeDoJogo = bg.names
                            .Where(n => n.is_principal)
                            .Select(n => n.name)
                            .FirstOrDefault() ?? ""
                    })
                    .ToList<object>();

                return games;
            }
        }

        public List<object> SearchGamesByNameOrBarcode(string searchTerm)
        {
            using (var context = new AppDbContext())
            {
                var gamesQuery = context.BoardGames.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    gamesQuery = gamesQuery.Where(bg =>
                        bg.names.Any(n => n.is_principal && n.name.Contains(searchTerm)) ||
                        bg.codes.Any(c => c.bar_code.Contains(searchTerm))
                    );
                }

                // Realiza a projeção para o formato desejado
                var games = gamesQuery
                    .Select(bg => new
                    {
                        ID = bg.id,
                        NomeDoJogo = bg.names
                            .Where(n => n.is_principal)
                            .Select(n => n.name)
                            .FirstOrDefault() ?? "",

                        Barcode = bg.codes
                            .Select(c => c.bar_code)
                            .FirstOrDefault() ?? ""
                    })
                    .ToList<object>();

                return games;
            }
        }


    }




}


namespace HappyEnglishWebApi.CustomExeption
{
    class InvalidGamerIdException : Exception
    {
        public InvalidGamerIdException() { }

        public InvalidGamerIdException(long id)
            : base(String.Format($"Gamer with id: {id} doesn't exist in the database."))
        {

        }
    }
}




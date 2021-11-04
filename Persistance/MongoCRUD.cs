using System;
using System.Collections.Generic;
using MongoDB.Driver;   
using MongoDB.Bson;

namespace Persistance
{
    public static class MongoCRUD
    {
        private static IMongoDatabase database;
        public static void Initialize(string databaseName)
        {
            var client = new MongoClient();
            database = client.GetDatabase(databaseName);
        }

        public static void InsertRecord<T>(string table, T record)
        {
            var collection = database.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public static void DeleteRecord<T>(string table, Guid id)
        {
            var collection = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }

        public static void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = database.GetCollection<T>(table);
            var result = collection.ReplaceOne(new BsonDocument("Id", id), record, new UpdateOptions{IsUpsert = true});
        }

        public static List<T> LoadCollection<T>(string table)
        {
            var collection = database.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public static T LoadDocumentByID<T>(string table, Guid id)
        {
            var collection = database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }
    }
}
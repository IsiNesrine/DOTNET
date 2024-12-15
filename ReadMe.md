# ReadMe.md

## 1. Introduction

Bienvenue sur le projet **Uni'vert'sité**, une plateforme innovante permettant de cultiver la cohésion et de partager des idées au sein d'un campus fictif. Cette application propose des fonctionnalités telles que la gestion d'événements, l'inscription des étudiants et la gestion spécifique pour les enseignants.

## 2. Prérequis

Avant de commencer, assurez-vous d'avoir les logiciels suivants installés :

- **.NET SDK 9.0**
- **SQL Server Express**
- **Visual Studio 2022** (ou tout autre IDE compatible avec .NET)
- **Git** (pour cloner le dépôt)

### Versions supportées

- Windows 10 ou supérieur
- .NET SDK 9.0 ou supérieur

## 3. Installation

### Étape 1 : Installation de .NET SDK

1. Rendez-vous sur [le site officiel de .NET](https://dotnet.microsoft.com/download).
2. Téléchargez et installez la version **.NET SDK 9.0**.
3. Vérifiez l'installation :
   ```bash
   dotnet --version
   ```

### Étape 2 : Installation de SQL Server Express

1. Téléchargez SQL Server Express depuis [le site officiel de Microsoft](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
2. Installez SQL Server Express en activant les services de base de données.
3. Installez **SQL Server Management Studio (SSMS)** pour gérer facilement vos bases de données.

### Étape 3 : Configuration de la base de données

1. Créez une nouvelle base de données nommée `UnivertsiteDB`.
2. Notez les informations de connexion (nom du serveur, identifiant, mot de passe).

### Étape 4 : Clonage du projet

1. Clonez le dépôt Git en local :
   ```bash
   git clone https://github.com/MaxYvesMastrodicasa/DOTNET.git
   ```
2. Naviguez dans le dossier du projet :
   ```bash
   cd mvcTemplate
   ```

## 4. Configuration

### Chaîne de connexion SQL Server

1. Ouvrez le fichier `appsettings.json`.
2. Configurez la chaîne de connexion :
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=UnivertsitéDB;Trusted_Connection=True;"
   }
   ```

### Migration de la base de données

1. Appliquez les migrations Entity Framework :
   ```bash
   dotnet ef database update
   ```

### Configuration des rôles utilisateurs

1. Les utilisateurs sont créés avec les rôles `Teacher` et `Student` selon leur type lors de l'inscription.

## 5. Lancement

### Commandes pour démarrer l'application

1. Lancez l'application :
   ```bash
   dotnet run
   ```
2. Ouvrez votre navigateur à l'adresse :
   ```
   http://localhost:5081
   ```

## 6. Utilisation

### Connexion et inscription

- Les utilisateurs peuvent s'inscrire en tant que **enseignant (Teacher)** ou **étudiant (Student)**.
- Une fois connecté, ils accèdent à des fonctionnalités personnalisées selon leur rôle.

### Gestion des événements

- **Enseignants** : Créer, modifier et supprimer des événements.
- **Étudiants** : S'inscrire et se désinscrire des événements.

## 7. Fonctionnalités du site

- **Pour les enseignants** :

  - Création d'événements
  - Modification et suppression

- **Pour les étudiants** :
  - Inscription et désinscription à des événements

## 8. Crédits

Projet réalisé par Max-Yves Mastrodicasa.

Ce projet est actuellement en cours de migration vers une solution basée sur Blazor.

namespace trello;

public static class RepoTools {

    public static Repository<User> repoUser = new();
    public static Repository<Project> repoProject = new();
    public static Repository<ProjectUser> repoProjectUser = new();
    public static Repository<List> repoList = new();
    public static Repository<Card> repoCard = new();
    public static Repository<Comment> repoComment = new();
    public static Repository<Tag> repoTag = new();

}
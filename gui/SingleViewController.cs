using Godot;

public class SingleViewController : Controller
{

    private string viewPath;

    public SingleViewController(string viewPath)
    {
        this.viewPath = viewPath;
    }

    public override PackedScene LoadView()
    {
        string fullPath = "res://ressources/scenes/views/" + viewPath + ".tscn";
        return ResourceLoader.Load<PackedScene>(fullPath);
    }
}
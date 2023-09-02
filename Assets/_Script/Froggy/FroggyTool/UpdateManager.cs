using System;

public class UpdateManager : UnitySingleton_D<UpdateManager>
{
    public Action OnUpdate;

    private void Update()
    {
        OnUpdate?.Invoke();
    }
}
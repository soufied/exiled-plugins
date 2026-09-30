using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API;

namespace CustomRoleContainmentEngineer
{
  public class Plugin : Plugin<Configs.Config, Configs.Translation>
  {
    public override string Name => "CustomRoleContainmentEngineer";
    public override string Author => "_soufi";
    public override Version Version => new Version(1, 0, 0);
    public override Version RequiredExiledVersion => new Version(7, 2, 0);
    public static Plugin Singleton = new Plugin();
    public Api.Roles.ContainmentEngineer ContainmentEngineer;
    public override void OnEnabled()
    {
      Singleton = this;
      base.OnEnabled();
      ContainmentEngineer = new Api.Roles.ContainmentEngineer { Role = Config.Role };
      ContainmentEngineer.Register();
    }
    public override void OnDisabled()
    {
      ContainmentEngineer.Unregister();
      Singleton = null;
      base.OnDisabled();
    }
  }
}
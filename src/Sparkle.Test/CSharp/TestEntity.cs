using System.Numerics;
using Jitter2.Collision.Shapes;
using Jitter2.LinearMath;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Interact;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle.Test.CSharp;

public class TestEntity : Entity {
    
    public TestEntity(Vector3 position) : base(position) {
        
        // RENDERER
        ModelRenderer modelRenderer = new ModelRenderer(TestGame.PlayerModel, Vector3.Zero, Color.White, TestGame.Animations);
        modelRenderer.AnimationPlayer?.Play(2, true, 0.0F);
        this.AddComponent(modelRenderer);
        
        // PHYSICS
        this.AddComponent(new RigidBody3D(new BoxShape(2, 4, 2)));
    }
    
    protected override void FixedUpdate() {
        base.FixedUpdate();
        
        RigidBody3D body3D = this.GetComponent<RigidBody3D>();
        
        if (!body3D.World.RayCast(new JVector(this.Position.X, this.Position.Y - 8, this.Position.Z), -JVector.UnitY, default, default, out Shape? shape, out JVector normal, out float fraction)) {
            body3D.AddForce(new Vector3(0, 200, 0));
        }
    }

    protected override void Update() {
        base.Update();
        
        
        //if (Input.IsKeyPressed(KeyboardKey.One)) {
        //    this.GetComponent<ModelRenderer>().AnimationPlayer?.Play(0, false, 0.5F);
        //}
        //
        //if (Input.IsKeyPressed(KeyboardKey.Two)) {
        //    this.GetComponent<ModelRenderer>().AnimationPlayer?.Play(1, false, 0.5F);
        //}
        //        
        //if (Input.IsKeyPressed(KeyboardKey.Three)) {
        //    this.GetComponent<ModelRenderer>().AnimationPlayer?.Play(2, false, 0.5F);
        //}
        //
        //if (Input.IsKeyPressed(KeyboardKey.O)) {
        //    this.GetComponent<ModelRenderer>().AnimationPlayer?.Stop();
        //}
        //
        //if (Input.IsKeyPressed(KeyboardKey.P)) {
        //    this.GetComponent<ModelRenderer>().AnimationPlayer?.Pause();
        //}
        //
        //if (Input.IsKeyPressed(KeyboardKey.L)) {
        //    this.GetComponent<ModelRenderer>().AnimationPlayer?.UnPause();
        //}
    }
}
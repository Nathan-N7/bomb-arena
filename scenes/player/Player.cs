using Godot;

namespace BombArena.Scenes.Player;

public partial class Player : CharacterBody3D
{
	private float _baseSpeed = 5.0f;
	private float _maxSpeed = 7.0f;
	private float _speedGrowth = 0.05f;
	private float _elapsedTime = 0.0f;
	
	private float GetCurrentSpeed()
	{
		return Mathf.Min(_baseSpeed + _elapsedTime * _speedGrowth, _maxSpeed);
	}

	private Vector3 GetInputDirection()
	{
		Vector3 direction = Vector3.Zero;
		if (Input.IsActionPressed("move_forward"))
		{
			direction += Vector3.Forward;
		}
		if (Input.IsActionPressed("move_backward"))
		{
			direction += Vector3.Back;
		}
		if (Input.IsActionPressed("move_left"))
		{
			direction += Vector3.Left;
		}
		if (Input.IsActionPressed("move_right"))
		{
			direction += Vector3.Right;
		}
		return direction.Normalized();
	}

	private void VelocityUpdate(double delta)
	{
		GD.Print("physics rodando");
		_elapsedTime += (float)delta;
		Velocity = GetCurrentSpeed() * GetInputDirection();
	}

	public override void _PhysicsProcess(double delta)
	{
		VelocityUpdate(delta);
		MoveAndSlide();
	}

	public override void _Ready()
	{
	}
}

<?php

use Illuminate\Auth\UserTrait;
use Illuminate\Auth\UserInterface;
use Illuminate\Auth\Reminders\RemindableTrait;
use Illuminate\Auth\Reminders\RemindableInterface;

class User extends Eloquent implements UserInterface, RemindableInterface {

	use UserTrait, RemindableTrait;

	/**
	 * The database table used by the model.
	 *
	 * @var string
	 */
    protected $table = 'users';
	protected $fillable = array('username', 'password', 'password_confirm', 'name', 'last_name', 'email');

	public static $rules = array(
		'username'         => 'required|unique:users',
        'password'         => 'required',    
        'password_confirm' => 'required|same:password',
        'name'             => 'required|alpha',
        'last_name'        => 'required|alpha',
        'email'            => 'required|email|unique:users'
	);

	/**
	 * The attributes excluded from the model's JSON form.
	 *
	 * @var array
	 */
	protected $hidden = array('password', 'remember_token');

}

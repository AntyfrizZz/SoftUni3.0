<?php

class HomeController extends BaseController {

	/*
	|--------------------------------------------------------------------------
	| Default Home Controller
	|--------------------------------------------------------------------------
	|
	| You may wish to use controllers instead of, or in addition to, Closure
	| based routes. That's great! Here is an example controller method to
	| get you started. To route to this controller, just add the route:
	|
	|	Route::get('/', 'HomeController@showWelcome');
	|
	*/

	public function showRegister()
	{
		// show the form
		return View::make('register');
	}

	public function doRegister()
	{
		$messages = array(
        'required' => 'The :attribute is really really really important.',
        'same'  => 'The :others must match.',
        'alpha' => 'The field should contain only letters'
    	);

	    $validator = Validator::make(Input::all(), User::$rules);

	    // check if the validator failed -----------------------
	    if ($validator->fails()) {

	        // redirect our user back with error messages       
	        $messages = $validator->messages();

	        // also redirect them back with old inputs so they dont have to fill out the form again
	        // but we wont redirect them with the password they entered

	        return Redirect::to('register')
	            ->withErrors($validator)
	            ->withInput(Input::except('password', 'password_confirm'));

	    } else {
	        // validation successful ---------------------------

	        // create the data
	        $users = new User;    
	        $users->username = Input::get('username');
	        $users->password = Hash::make(Input::get('password'));
	        $users->name = Input::get('name');
	        $users->last_name = Input::get('last_name');
	        $users->email = Input::get('email');
	        $users->save();

	        //$name = Input::get('name');
	        //return View::make('index')->with('name', $name);
            return Redirect::to('/')->with('flash-content', "You are registered");

	    }
	}

	public function showLogin()
	{
		// show the form
		return View::make('login');
	}

	public function doLogin()
	{
		$rules = array(
			'username' => 'required',
			'password' => 'required'
		);

		// run the validation rules on the inputs from the form
		$validator = Validator::make(Input::all(), $rules);

		// if the validator fails, redirect back to the form
		if ($validator->fails()) {
			return Redirect::to('login')
				->withErrors($validator) // send back all errors to the login form
				->withInput(Input::except('password')); // send back the input (not the password) so that we can repopulate the form
		} else {

			// create our user data for the authentication
			$userdata = array(
				'username' 	=> Input::get('username'),
				'password' 	=> Input::get('password')
			);

			// attempt to do the login
			if (Auth::attempt($userdata)) {

				// validation successful!
				// redirect them to the secure section or whatever
				// return Redirect::to('secure');
				// for now we'll just echo success (even though echoing in a controller is bad)
				return Redirect::intended('/');

			} else {	 	

				// validation not successful, send back to form	
				return Redirect::to('login');
			}
		}

	}

	public function doLogout()
	{
		Auth::logout(); // log the user out of our application
		return Redirect::to('/'); // redirect the user to the login screen
	}
}

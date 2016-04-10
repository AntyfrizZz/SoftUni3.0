<?php

class AdminController extends BaseController {

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

	public function showLogin()
	{
		// show the form
		return View::make('admin.login');
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
			return Redirect::to('admin/login')
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
                $isAdmin = strpos($userdata['username'], '_admin');
                if($isAdmin !== false)
                {
                    return Redirect::intended('admin/');
                }
                else{
                    return Redirect::intended('/');
                }

			} else {	 	

				// validation not successful, send back to form	
				return Redirect::to('admin/login');
			}
		}

	}

	public function doLogout()
	{
		Auth::logout(); // log the user out of our application
		return Redirect::to('/admin'); // redirect the user to the login screen
	}
}

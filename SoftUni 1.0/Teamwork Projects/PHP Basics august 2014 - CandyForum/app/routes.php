<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It's a breeze. Simply tell Laravel the URIs it should respond to
| and give it the Closure to execute when that URI is requested.
|
*/

Route::get('/', function(){
	return View::make('index');
});

Route::get('/register', array('uses' => 'HomeController@showRegister'));
Route::post('/register', array('uses' => 'HomeController@doRegister'));
Route::get('/login', array('uses' => 'HomeController@showLogin'));
Route::post('/login', array('uses' => 'HomeController@doLogin'));
Route::get('logout', array('uses' => 'HomeController@doLogout'));
Route::get('/tags', function(){
    $tags = Tags::getTags();
    return Response::json($tags);
});
Route::post('posts/show/search', array('uses' => 'PostController@search'));

/* --- POSTS ROUTES --- */
Route::get('user/posts/show', array('uses' => 'PostController@userPosts'));
Route::get('posts/show', array('uses' => 'PostController@index'));
Route::post('posts', array('before' => 'csrf', 'uses' => 'PostController@store'));
Route::get('posts/create', array('before' => 'auth', 'uses' => 'PostController@create'));
Route::get('posts/show/category/{id}', array('uses' => 'PostController@show@$id'));
Route::get('posts/show/{id}', array('uses' => 'PostController@showPost@$id'));
Route::post('posts/show/{id}', array('uses' => 'AnswerController@store@$id'));

/* --- ADMIN ROUTES --- */
Route::get('admin', function(){
    return View::make('admin.index');
});
Route::get('admin/login', array('uses' => 'AdminController@showLogin'));
Route::post('admin/login', array('uses' => 'AdminController@doLogin'));
Route::get('admin/logout', array('uses' => 'AdminController@doLogout'));
Route::get('admin/posts/show', array('uses' => 'PostAdminController@index'));
Route::get('admin/posts/{id}/edit', array('uses' => 'PostAdminController@edit@$id'));
Route::post('admin/posts/{id}/edit', array('uses' => 'PostAdminController@update@$id'));
Route::get('admin/posts/{id}/delete', array('uses' => 'PostAdminController@destroy@$id'));

App::missing(function($e) {
    //return Response::view('index', array(), 404);
    return Redirect::to('/');
});
<?php

class AnswerController extends \BaseController {

	/**
	 * Display a listing of the resource.
	 *
	 * @return Response
	 */
	public function index()
	{
		//
	}


	/**
	 * Show the form for creating a new resource.
	 *
	 * @return Response
	 */
	public function create()
	{
		//
	}


	/**
	 * Store a newly created resource in storage.
	 *
	 * @return Response
	 */
	public function store($id)
	{
        $answer = new Answer;
        $answer->content = $_POST['content'];
        if(Auth::id() == 0)
        {
            $answer->author = $_POST['author'];
        }
        else{
            $answer->author = Auth::user()->username;
        }
        $answer->post_id = $id;
        $answer->author_id = $_POST['author_id'];
        $answer->save();
        $post = Posts::allPosts($id);
        //return View::make('posts.show')->with('post',$post);
        return Redirect::to('posts/show/'.$id)->with('post',$post);
	}


	/**
	 * Display the specified resource.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function show($id)
	{
		//
	}


	/**
	 * Show the form for editing the specified resource.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function edit($id)
	{
		//
	}


	/**
	 * Update the specified resource in storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function update($id)
	{
		//
	}


	/**
	 * Remove the specified resource from storage.
	 *
	 * @param  int  $id
	 * @return Response
	 */
	public function destroy($id)
	{
		//
	}


}

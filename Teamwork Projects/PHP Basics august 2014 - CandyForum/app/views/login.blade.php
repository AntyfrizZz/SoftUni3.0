@extends('layouts/default')
@section('content')
<style type="text/css">
	label{
		padding: 5px;
		margin: 5px 5px 5px 0px;
	}

	input{
		width: 300px;
		padding: 5px;
	}

	input[type="submit"]{
		width: 150px;
		margin-top: 10px;
	}

	form{
		margin-bottom: 25px;
	}
</style>
<section>
	<h1> Log In</h1>
	{{ Form::open(array('url' => 'login')) }}
	{{ Form::label('username', 'Username') }}
	<br />
	{{ Form::text('username') }}
	<br />
	{{ Form::label('password', 'Password') }}
	<br />
	{{ Form::password('password') }}
	<br />
	{{ Form::submit('Log In') }}

	{{ Form::close() }}
</section>
@stop
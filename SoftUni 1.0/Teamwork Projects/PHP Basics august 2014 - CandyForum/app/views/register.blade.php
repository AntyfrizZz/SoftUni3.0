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

    form p{
        color: #ff0000;
        margin: 0px;
        margin-bottom: -33px;
    }
</style>
<section>

    <h1> Sign Up!</h1>
    <h2>New User Registration</h2>
    {{ Form::open(array('url' => 'register')) }}
        {{ Form::label('username', 'Username') }}
        <br />
        {{ Form::text('username') }}
        @if ($errors->has('username')) <p>{{ $errors->first('username') }}</p> @endif
        <br />
        {{ Form::label('password', 'Password') }}
        <br />
        {{ Form::password('password') }}
        @if ($errors->has('password')) <p>{{ $errors->first('password') }}</p> @endif
        <br />
        {{ Form::label('password_confirm', 'Confirm Password') }}
        <br />
        {{ Form::password('password_confirm') }}
        @if ($errors->has('password_confirm')) <p>{{ $errors->first('password_confirm') }}</p> @endif
        <br />
        {{ Form::label('name', 'Name') }}
        <br />
        {{ Form::text('name') }}
        @if ($errors->has('name')) <p>{{ $errors->first('name') }}</p> @endif
        <br />
        {{ Form::label('last_name', 'Last Name') }}
        <br />
        {{ Form::text('last_name') }}
        @if ($errors->has('last_name')) <p>{{ $errors->first('last_name') }}</p> @endif
        <br />
        {{ Form::label('email', 'Email Address') }}
        <br />
        {{ Form::text('email') }}
        @if ($errors->has('email')) <p>{{ $errors->first('email') }}</p> @endif
        <br />
        {{ Form::submit('Sign Up') }}

    {{ Form::close() }}
</section> 
@stop
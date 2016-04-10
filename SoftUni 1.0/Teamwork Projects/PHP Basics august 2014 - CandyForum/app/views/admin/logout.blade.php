@extends('layouts/admin')
@section('content')
<h1> Log Out</h1>
<p>You successfully logged out.<a href="{{ URL::to('/login') }}">Log In?</a></p>
@stop

@extends ('layouts.default')
@section ('content')
<style type="text/css">
    #comment-form{
        margin-top:20px;
    }

    input{
        width:99%;
        margin: 5px 0px;
        padding: 5px 1px 5px 5px;
    }

    input[type="submit"], select {
        width: auto;
        padding: 5px;
    }

    input[type="submit"]{
        float:right;
    }

    select{
        float: left;
        margin-top:10px;
        width:350px;
    }
    .ui-menu .iu-menu-item{
	z-index: 100 !important;
	background: red !important;
}
</style>
<h1>Ask new question</h1>
<form action="/posts" method="post" id="comment-form" class="col-lg-12 form-group">
    <input type="hidden" name="_token" value="{{ csrf_token() }}"/>
    <input type="text" name="header" placeholder="Title..." class="form-control"/>
    <textarea name="content" id="editor" class="form-control"></textarea>
    <script>
        CKEDITOR.replace('editor');
    </script>
    <input style="z-index: 50 !important;" name="tags" id="tags" class="form-control" placeholder="Tags..." />
    <script src="{{ asset('./js/autocomplete.js') }}"></script>
    <select class="form-control" name="category">
        <option value="-1" disabled selected>Category</option>
        <?php $categories = Category::all(); ?>
        @foreach($categories as $category)
        <option value="{{ $category->id }}">{{ $category->name }}</option>
        @endforeach
    </select>
    <input type="submit" value="Submit" class="btn btn-md btn-default"/>
</form>
@stop
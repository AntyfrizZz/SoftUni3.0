@extends('layouts.default')
@section('content')
<div class="date-outer">
    <div class="date-posts">
        <div class="post-outer">
        	<?php foreach ($posts as $post) {?>
	            <article class="post hentry">
	                <div class="post-body entry-content clearfix">
	                    <div class="bpostmeta">
	                        <span><i class="fa fa-clock-o"></i><?php echo date("jS F, Y", strtotime($post["created_at"])); ?></span>
	                        <span><i class="fa fa-user"></i> Posted by <?php echo $post["author"]; ?></span>
	                        <span><i class="fa fa-bookmark"></i><?php echo $post["tags"];?></span>
	                        <span><i class="fa fa-clock-o"></i><?php echo $post['views']; ?></span>
	                    </div>
	                    <h2 class="post-title entry-title"><span class="post_title_icon"></span>
	                        <a href="/posts/show/{{ $post['id'] }}"><?php echo htmlentities($post["header"]);?></a>
	                    </h2>
	                
	                    <div class="entry-colors">
	                        <div class="color_col_1"></div>
	                        <div class="color_col_2"></div>
	                        <div class="color_col_3"></div>
	                    </div>
	                    <div id="">
	                        <div>{{ htmlspecialchars(stripslashes($post['content'])) }}</div>
	                    </div>
	                </div>
	            </article>
	            <div style="clear: both;"></div>
            <?php } ?>
        </div>
    </div>
</div>
</div>
<div style="clear: both;"></div>
@stop
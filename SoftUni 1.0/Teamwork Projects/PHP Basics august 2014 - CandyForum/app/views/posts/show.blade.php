@extends ('layouts.default')
@section ('content')
<?php 
    $answers = $post["answers"]; 
    $post = $post["post"][0];
?>
<div class="date-outer">
    <div class="date-posts">
        <div class="post-outer">
            <article class="post hentry">
                <div class="post-body entry-content clearfix">
                    <div class="bpostmeta">
                        <span><i class="fa fa-clock-o"></i><?php echo date("jS F, Y", strtotime($post["created_at"])); ?></span>
                        <span><i class="fa fa-user"></i> Posted by <?php echo $post["author"]; ?></span>
                        <span><i class="fa fa-bookmark"></i><?php echo $post["tags"];?></span>
                        <span><i class="fa fa-clock-o"></i><?php echo $post['views']; ?></span>
                    </div>
                    <h2 class="post-title entry-title">
                        <a href="/posts/show/{{ $post['id'] }}"><?php echo htmlentities($post["header"]);?></a>
                    </h2>
                
                    <div class="entry-colors">
                        <div style="width: 100%;" class="color_col_1"></div>
                    </div>
                    <div id="">
                        <div><?php echo htmlspecialchars_decode($post["content"]); ?></div>
                    </div>
                </div>
            </article>
            <div style="clear: both;"></div>

            <article class="post hentry">
                <div class="post-body entry-content clearfix">
                    <h2 class="post-title entry-title">Answers</h2>
                    <div class="entry-colors">
                        <div  style="width: 100%;" class="color_col_2"></div>
                    </div>
                    <div id="">
                        <?php foreach ($answers as $answer) { ?>
                            <div>
                                <div class="bpostmeta">
                                    <span><i class="fa fa-clock-o"></i><?php echo date("jS F, Y", strtotime($answer["created_at"])); ?></span>
                                    <span><i class="fa fa-user"></i> Answered by <?php echo $answer["author"]; ?></span>
                                </div>
                                <div>
                                    <?php echo $answer["content"]; ?>
                                </div>
                            </div>
                        <?php } ?>
                    </div>
                    <div>
                        <div class="thread">
                            <div class="answerBox"></div>
                            <button style="float:right;" id="answer-button" type="button" onclick="addAnswer()">Add new answer</button>
                            <form action="" method="post" id="answer-form" class="col-lg-12 form-group">
                                <h2>Add new answer</h2>
                                <input type="hidden" name="_token" value="{{ csrf_token() }}"/>
                                <input type="hidden" name="author_id" value="{{ Auth::id() }}"/>
                                @if(Auth::id() == 0)
                                    <input style="width: 280px; padding: 5px; margin: 5px 5px 5px 0px;" type="email" name="author" required placeholder="Enter email"/>
                                @endif
                                <textarea name="content" id="answer" class="form-control"></textarea>
                                <input style="padding: 5px; margin: 5px;margin-left:0px;" type="submit" value="Submit" class="btn btn-md btn-default"/>

                                <script>
                                    CKEDITOR.replace('answer');
                                </script>
                            </form>
                        </div>
                    </div>
                </div>
            </article>
            <div style="clear: both;"></div>
        </div>
    </div>
</div>

<script>
    //$('#answer-form').hide();
    document.getElementById('answer-form').style.display = 'none';
    $("#answer-button").live("click", function(){
        $(this).hide();
    });
</script>
@stop
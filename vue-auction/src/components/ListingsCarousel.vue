<template>
  <section>
    <b-carousel-list
      v-model="values"
      :data="items"
      :arrow-hover="arrowHover"
      :items-to-list="perList"
      :has-drag="drag"
    >
      <template slot="item" slot-scope="props">
        <div class="card">
          <div class="card-image">
            <figure class="image is-5by4">
              <a @click="info(props.index)"><img :src="props.list.image"/></a>
            </figure>
            <b-tag type="is-info" rounded style="position: absolute; top: 0;">
              <p class="control" style="margin-left: auto">
                {{ `$ ${props.list.price}` }}
              </p></b-tag
            >
          </div>
          <div class="card-content">
            <div class="content">
              <p class="title is-6">{{ props.list.title }}</p>
              <p class="subtitle is-7">Caption will go here</p>
            </div>
          </div>
        </div>
      </template>
    </b-carousel-list>
  </section>
</template>

<script>
export default {
  name: "ListingsCarousel",
  data() {
    return {
      arrowHover: false,
      drag: true,
      values: 1,
      perList: 1,
      items: [
        {
          title: "Slide 1",
          image: "https://picsum.photos/id/0/1230/500",
        },
        {
          title: "Slide 2",
          image: "https://picsum.photos/id/1/1230/500",
        },
        {
          title: "Slide 3",
          image: "https://picsum.photos/id/2/1230/500",
        },
        {
          title: "Slide 4",
          image: "https://picsum.photos/id/3/1230/500",
        },
        {
          title: "Slide 5",
          image: "https://picsum.photos/id/4/1230/500",
        },
        {
          title: "Slide 6",
          image: "https://picsum.photos/id/5/1230/500",
        },
        {
          title: "Slide 7",
          image: "https://picsum.photos/id/6/1230/500",
        },
        {
          title: "Slide 8",
          image: "https://picsum.photos/id/7/1230/500",
        },
      ],
    };
  },
};
</script>

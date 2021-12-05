<template>
  <div class="showcase">
    <header class="showcase__header">
      <showcase-title>
        {{ title }}
      </showcase-title>
      <router-link class="link showcase__header-create" :to="linkToCreate">
        <file-plus-icon />
        {{ createCaption }}
      </router-link>
    </header>
    <section class="showcase__search">
      <div class="showcase__search-title">
        Поиск по:
      </div>
      <div class="showcase__search-row">
        <input-field
          v-model="searchValue"
          placeholder="Поиск"
        />
        <filter-board class="showcase__search-radio" title="Поле поиска">
          <label
            v-for="(sort, index) in sortTypes"
            :key="index"
          >
            <input
              type="radio"
              class="form-check-input"
              :value="sort"
              v-model="sortValue"
            >
            {{ sort }}
          </label>
        </filter-board>
      </div>
    </section>
    <section
      class="showcase__result"
    >
      <table class="table">
        <thead>
        <tr>
          <th
            v-for="(head, index) in tableHeaders"
            :key="index"
          >
            {{ head }}
          </th>
        </tr>
        </thead>
        <tbody>
        <tr
          v-for="(row, index) in tableData"
          :key="index"
        >
          <td
            v-for="(cell, innerIndex) in row"
            :key="innerIndex"
          >
            {{ cell }}
          </td>
        </tr>
        </tbody>
      </table>
    </section>
  </div>
</template>

<script>
import ShowcaseTitle from './showcase-title'
import InputField from '@/components/UI/inputField'
import FilterBoard from '@/components/Filterboard'
import { FilePlusIcon } from '@iconicicons/vue3'

export default {
  name: 'Showcase',
  components: {
    ShowcaseTitle,
    InputField,
    FilterBoard,
    FilePlusIcon
  },
  data: () => {
    return {
      searchValue: '',
      sortValue: ''
    }
  },
  props: {
    title: {
      type: String,
      require: true
    },
    linkToCreate: {
      type: String,
      require: true
    },
    createCaption: {
      type: String,
      require: true
    },
    tableHeaders: {
      type: Array,
      default: () => ([])
    },
    tableData: {
      type: Array,
      default: () => ([])
    },
    sortTypes: {
      type: Array,
      default: () => ([])
    }
  }
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.showcase {
  text-align: left;

  &__header {
    &-create {
      font-weight: 600;
      display: flex;
    }
  }

  &__search {
    margin: $gap-l 0;

    &-title {
      font-size: $font-size-l;
      font-weight: 600;
      margin-bottom: 5px;
    }

    &-radio {
      max-width: $filterWidth;
      margin-top: 20px;
    }
  }

  &__result {
    width: 100%;
    text-align: left;
    overflow-x: auto;
  }
}
</style>

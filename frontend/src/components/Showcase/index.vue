<template>
  <div class="showcase">
    <showcase-header
      :title="title"
      :create-caption="createCaption"
      :link-to-create="linkToCreate"
    />

    <section v-if="enableSearch" class="showcase__search">
      <div class="showcase__search-title">
        Поиск:
      </div>
      <div class="showcase__search-row">
        <input-field
          v-model="searchValue"
          placeholder="Поиск"
          class="showcase__search-input"
          @input="onSearch"
        />
        <filter-board class="showcase__search-radio" title="Поле поиска">
          <label
            v-for="(sort, index) in sortTypes"
            :key="index"
          >
            <input
              type="radio"
              class="form-check-input"
              :value="sort.value"
              v-model="sortValue"
              @change="onSearch"
            >
            {{ sort.text }}
          </label>
        </filter-board>
      </div>
    </section>

    <transition name="fade" mode="out-in">
      <section v-show="tableData.length" class="showcase__result">
        <editing-table
          :table-headers="tableHeaders"
          :table-data="tableData"
        />
      </section>
    </transition>
  </div>
</template>

<script>
import ShowcaseHeader from './showcase-header'
import EditingTable from '@/components/EditingTable'
import InputField from '@/components/UI/inputField'
import FilterBoard from '@/components/Filterboard'

export default {
  name: 'Showcase',
  components: {
    InputField,
    ShowcaseHeader,
    EditingTable,
    FilterBoard
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
    enableSearch: {
      type: Boolean,
      default: false
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
  },
  mounted () {
    if (this.sortTypes && this.sortTypes.length) {
      this.sortValue = this.sortTypes[0]
    }
  },
  methods: {
    onSearch () {
      if (this.sortValue && this.searchValue) {
        this.$emit('onSearch', { value: this.searchValue, sortValue: this.sortValue })
      }
    }
  },
  emits: ['onSearch']
}
</script>

<style lang="scss">
@import "~@/styles/variables";

.showcase {
  text-align: left;

  &__search {
    margin: $gap-l 0;

    &-input {
      max-width: 320px;
    }

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
}
</style>

<template>
  <showcase-create class="report" title="Отчеты">
    <ul class="nav nav-tabs mb-5">
      <li
        v-for="(tab, index) in tabs"
        :key="index"
        class="nav-item"
        @click="setActiveTab(tab)"
      >
        <a
          :class="[
            'nav-link',
            {
              'active': tab.isActive
            }
          ]">
          {{ tab.title }}
        </a>
      </li>
    </ul>

    <showcase-report-cell
      title="Стоимость заказа и список его товаров"
      v-if="activeTab('Стоимость заказа и список его товаров')"
    >
      <showcase-label-field label="Введите номер заказа">
        <input type="text" class="form-control">
      </showcase-label-field>

      <layout-button class="mb-2">
        Найти
      </layout-button>

      <div>
        <span class="fw-bolder d-block">Заказ №34525</span>
        <span class="fw-bolder d-block">Общая стоимость: 50 000</span>
        <div style="width: 100%; overflow-x: auto">
          <table class="table table-responsive">
            <thead>
            <tr>
              <th>
                Артикул
              </th>
              <th>
                Производитель
              </th>
              <th>
                Наименование
              </th>
              <th>
                Тип
              </th>
              <th>
                Категория
              </th>
              <th>
                Кол-во
              </th>
              <th>
                Стоимость
              </th>
            </tr>
            </thead>
            <tbody>
            <tr>
              <td v-for="(item, index) in outDate" :key="index">
                {{ item }}
              </td>
            </tr>
            </tbody>
          </table>
        </div>
      </div>
    </showcase-report-cell>

    <showcase-report-cell
      title="Поставщики с кол-вом поставок за период"
      v-if="activeTab('Поставщики с кол-вом поставок за период')"
    >
      <showcase-label-field label="Выберите начало периода">
        <input type="date" class="form-control">
      </showcase-label-field>

      <showcase-label-field label="Выберите конец периода">
        <input type="date" class="form-control">
      </showcase-label-field>

      <layout-button class="mb-2">
        Найти
      </layout-button>

      <table class="table">
        <thead>
        <tr>
          <th>
            №
          </th>
          <th>
            Поставщик
          </th>
          <th>
            Кол-во поставок
          </th>
        </tr>
        </thead>
        <tbody>
        <tr>
          <td>
           1
          </td>
          <td>
            Автотрейд
          </td>
          <td>
            142
          </td>
        </tr>
        <tr>
          <td>
            2
          </td>
          <td>
            ПЭК
          </td>
          <td>
            111
          </td>
        </tr>
        <tr>
          <td>
            3
          </td>
          <td>
            КИТ
          </td>
          <td>
            152
          </td>
        </tr>
        </tbody>
      </table>
    </showcase-report-cell>

    <showcase-report-cell
      title="Список заказов клиента"
      v-if="activeTab('Список заказов клиента')"
    >
      <showcase-label-field label="Введите номер клиента">
        <input type="text" class="form-control">
      </showcase-label-field>
    </showcase-report-cell>

    <showcase-report-cell
      title="Популярные товары"
      v-if="activeTab('Популярные товары')"
    >
      Тут будет график
    </showcase-report-cell>
  </showcase-create>
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import ShowcaseReportCell from '@/components/Showcase/showcase-report-cell'
import ShowcaseLabelField from '@/components/Showcase/showcase-label-field'
import LayoutButton from '@/components/Layouts/layout-button'

export default {
  name: 'Report',
  components: {
    LayoutButton,
    ShowcaseLabelField,
    ShowcaseReportCell,
    ShowcaseCreate
  },
  data: () => {
    return {
      outDate: {
        art: '97232',
        manufacture: 'Цемент-Завод 12',
        name: 'Цемент A500',
        type: 'Материал',
        category: 'Цемент',
        price: '5000',
        total: '50 000'
      },
      tabs: [
        {
          title: 'Стоимость заказа и список его товаров',
          isActive: true
        },
        {
          title: 'Поставщики с кол-вом поставок за период',
          isActive: false
        },
        {
          title: 'Список заказов клиента',
          isActive: false
        },
        {
          title: 'Популярные товары',
          isActive: false
        }
      ]
    }
  },
  methods: {
    setActiveTab (tab) {
      this.tabs.find((tab) => tab.isActive).isActive = false
      tab.isActive = true
    },

    activeTab (value) {
      return this.tabs.find((tab) => tab.title === value && tab.isActive)
    }
  }
}
</script>

<style lang="scss">
.report {
  .filter__items {
    display: block;
  }
}
</style>

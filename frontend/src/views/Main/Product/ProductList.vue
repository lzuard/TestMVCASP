<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'

export default {
  name: 'ProductList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список товаров',
        linkToCreate: '/products/create',
        createCaption: 'Создать товар',
        tableHeaders: [
          'Артикул',
          'Производитель',
          'Наименование',
          'Тип',
          'Категория',
          'Подкатегория',
          'Упаковка',
          'Кол-во в упаковке',
          'Кол-во на складе',
          'Цена',
          'Минимальный заказ',
          'Вес',
          'Высота',
          'Ширина',
          'Длинна',
          'Описание',
          'Уценен',
          'Причина'
        ],
        tableData: [
          {
            art: '97232',
            manufacture: 'Цемент-Завод 12',
            name: 'Цемент A500',
            type: 'Материал',
            category: 'Цемент',
            subcategory: 'А500',
            package_type: 'Мешок',
            package_num: '1',
            num: '874',
            price: '400',
            min_order: '40',
            weight: '50',
            height: '20',
            width: '30',
            length: '30',
            description: 'Цемент',
            is_discount: 'Нет',
            reason: ''
          }
        ],
        sortTypes: [
          'Артикул',
          'Производитель',
          'Наименование',
          'Тип',
          'Категория',
          'Подкатегория',
          'Упаковка',
          'Кол-во в упаковке',
          'Кол-во на складе',
          'Цена',
          'Минимальный заказ',
          'Вес',
          'Высота',
          'Ширина',
          'Длинна',
          'Описание',
          'Уценен',
          'Причина'
        ]
      }
    }
  }
}
</script>
